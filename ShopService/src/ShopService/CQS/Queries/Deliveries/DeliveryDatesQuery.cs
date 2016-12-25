﻿using System;
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
    public class DeliveryDatesQuery : IQuery<DeliveryDatesCriterion, List<DateTime>>
    {
        private readonly IQueryBuilder _queryBuilder;

        public DeliveryDatesQuery(IQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder;
        }

        public async Task<List<DateTime>> AskAsync(DeliveryDatesCriterion criterion)
        {
            var deliveryDates = new List<DateTime>();

            var showThreeMonthsAhead = criterion.ShowUntil;
            var subscriptionDatesCriterion = new SubscriptionDatesForSubscriptionCriterion();
            var subscriptionDates = await _queryBuilder.For<List<SubscriptionDate>>().WithAsync(subscriptionDatesCriterion);
            subscriptionDates = subscriptionDates.OrderByDescending(x => x.Date).ToList();
            var lastSubscriptionDate = subscriptionDates.FirstOrDefault();

            if (lastSubscriptionDate == null) return deliveryDates;
            if (lastSubscriptionDate.Type == SubscriptionDateType.Suspend && lastSubscriptionDate.Date <= criterion.Today)
                return deliveryDates;

            var subscriptionActiveIntervals = new List<SubscriptionActiveInterval>();

            SubscriptionActiveInterval activeInterval = null;
            foreach (var subscriptionDate in subscriptionDates)
            {
                if (subscriptionDate.Date <= criterion.Today) continue;

                if (subscriptionDate.Type == SubscriptionDateType.Suspend)
                {
                    activeInterval = new SubscriptionActiveInterval
                    {
                        BeginAt = criterion.Today,
                        EndAt = subscriptionDate.Date
                    };
                    subscriptionActiveIntervals.Add(activeInterval);
                }
                else
                {
                    activeInterval.EndAt = subscriptionDate.Date;
                }
            }

            var deliveryIntervalForSubscriptionCriterion = new DeliveryIntervalWithTemplateForSubscriptionCriterion();
            var deliveryInterval = await _queryBuilder.For<DeliveryInterval>().WithAsync(deliveryIntervalForSubscriptionCriterion);

            foreach (var subscriptionActiveInterval in subscriptionActiveIntervals)
            {
                var cronInstance = CrontabSchedule.Parse(deliveryInterval.CronString, CronStringFormat.WithSeconds);
                var nextOccurrences = cronInstance.GetNextOccurrences(subscriptionActiveInterval.BeginAt, subscriptionActiveInterval.EndAt);
                deliveryDates.AddRange(nextOccurrences);
            }

            return deliveryDates;
        }
    }
}