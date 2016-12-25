using System;
using ShopService.Conventions.CQS.Queries;

namespace ShopService.CQS.Criterions.Subscriptions
{
    public class SubscriptionViewModelCriterion : ICriterion
    {
        public SubscriptionViewModelCriterion(DateTime pointedTodayDate)
        {
            PointedTodayDate = pointedTodayDate;
        }

        public DateTime PointedTodayDate { get; set; }
    }
}