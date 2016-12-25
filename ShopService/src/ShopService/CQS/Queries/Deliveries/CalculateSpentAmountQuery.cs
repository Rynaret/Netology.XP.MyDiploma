using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NCrontab.Advanced;
using NCrontab.Advanced.Enumerations;
using ShopService.Conventions.CQS.Queries;
using ShopService.Conventions.Enums;
using ShopService.CQS.Criterions.DeliveryIntervals;
using ShopService.CQS.Criterions.Subscriptions;
using ShopService.Entities;
using ShopService.Models.SubscriptionViewModels;

namespace ShopService.CQS.Queries.Deliveries
{
    public class CalculateSpentAmountQuery : IQuery<CalculateSpentAmountCriterion, double>
    {
        private readonly IQueryBuilder _queryBuilder;

        public CalculateSpentAmountQuery(IQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder;
        }

        public async Task<double> AskAsync(CalculateSpentAmountCriterion criterion)
        {
            var subscriptionDatesCriterion = new SubscriptionDatesForSubscriptionCriterion();
            var subscriptionDates = await _queryBuilder.For<List<SubscriptionDate>>().WithAsync(subscriptionDatesCriterion);
            subscriptionDates = subscriptionDates.OrderBy(x => x.Date).ToList();
            var firstSubscriptionDate = subscriptionDates.FirstOrDefault();

            if (firstSubscriptionDate == null) return 0;
            if (firstSubscriptionDate.Date >= criterion.Today) return 0;

            var subscriptionActiveIntervals = new List<SubscriptionActiveInterval>();

            SubscriptionActiveInterval activeInterval = null;
            foreach (var subscriptionDate in subscriptionDates)
            {
                if (subscriptionDate.Type == SubscriptionDateType.Start)
                {
                    activeInterval = new SubscriptionActiveInterval(criterion.Today) {BeginAt = subscriptionDate.Date};
                }
                else
                {
                    activeInterval.EndAt = subscriptionDate.Date;
                    subscriptionActiveIntervals.Add(activeInterval);
                }
            }

            var deliveryIntervalForSubscriptionCriterion = new DeliveryIntervalWithTemplateForSubscriptionCriterion();
            var deliveryInterval = await _queryBuilder.For<DeliveryInterval>().WithAsync(deliveryIntervalForSubscriptionCriterion);

            double calculatedSpendedAmount = 0;

            foreach (var subscriptionActiveInterval in subscriptionActiveIntervals)
            {
                var cronInstance = CrontabSchedule.Parse(deliveryInterval.CronString, CronStringFormat.WithSeconds);
                var nextOccurrences = cronInstance.GetNextOccurrences(subscriptionActiveInterval.BeginAt, subscriptionActiveInterval.EndAt);
                calculatedSpendedAmount += nextOccurrences.Count() * criterion.SumOfProductsInSubscription;
            }

            return calculatedSpendedAmount;
        }
    }
}