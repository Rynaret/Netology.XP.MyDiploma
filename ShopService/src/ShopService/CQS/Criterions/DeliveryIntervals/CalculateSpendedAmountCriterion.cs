using System;
using ShopService.Conventions.CQS.Queries;

namespace ShopService.CQS.Criterions.DeliveryIntervals
{
    public class CalculateSpendedAmountCriterion : ICriterion
    {
        public CalculateSpendedAmountCriterion(DateTime today)
        {
            Today = today;
        }

        public DateTime Today { get; set; }
    }
}