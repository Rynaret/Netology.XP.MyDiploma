using System;
using ShopService.Conventions.CQS.Queries;

namespace ShopService.CQS.Criterions.DeliveryIntervals
{
    public class CalculateSpentAmountCriterion : ICriterion
    {
        public CalculateSpentAmountCriterion(DateTime today, double sumOfProductsInSubscription)
        {
            Today = today;
            SumOfProductsInSubscription = sumOfProductsInSubscription;
        }

        public DateTime Today { get; set; }
        public double SumOfProductsInSubscription { get; set; }
    }
}