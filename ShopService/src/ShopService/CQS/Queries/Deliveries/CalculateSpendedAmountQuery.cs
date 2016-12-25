using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NCrontab.Advanced;
using NCrontab.Advanced.Enumerations;
using ShopService.Conventions.CQS.Queries;
using ShopService.CQS.Criterions.DeliveryIntervals;
using ShopService.CQS.Criterions.Subscriptions;
using ShopService.Entities;

namespace ShopService.CQS.Queries.Deliveries
{
    public class CalculateSpendedAmountQuery : IQuery<CalculateSpendedAmountCriterion, double>
    {
        private readonly IQueryBuilder _queryBuilder;

        public CalculateSpendedAmountQuery(IQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder;
        }

        public async Task<double> AskAsync(CalculateSpendedAmountCriterion criterion)
        {
            var subscriptionDatesCriterion = new SubscriptionDatesForSubscriptionCriterion();
            var subscriptionDates = await _queryBuilder.For<List<SubscriptionDate>>().WithAsync(subscriptionDatesCriterion);
            subscriptionDates = subscriptionDates.OrderBy(x => x.Date).ToList();

            var firstSubscriptionDate = subscriptionDates.FirstOrDefault();

            if (firstSubscriptionDate == null) return 0;

            var deliveryIntervalForSubscriptionCriterion = new DeliveryIntervalWithTemplateForSubscriptionCriterion();
            var deliveryInterval = await _queryBuilder.For<DeliveryInterval>().WithAsync(deliveryIntervalForSubscriptionCriterion);

            // To get all instances between a range:

            var cronInstance = CrontabSchedule.Parse(deliveryInterval.CronString, CronStringFormat.WithSeconds);
            var start = DateTime.Parse("2015-01-01 00:00:00");
            var end = DateTime.Parse("2015-01-02 00:00:00");
            //var nextOccurrence = cronInstance.GetNextOccurrences(input);

            throw new System.NotImplementedException();
        }
    }
}