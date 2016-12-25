using System;
using ShopService.Conventions.CQS.Queries;

namespace ShopService.CQS.Criterions.DeliveryIntervals
{
    public class DeliveryDatesCriterion : ICriterion
    {
        public DeliveryDatesCriterion(DateTime today, DateTime showUntil)
        {
            Today = today;
            ShowUntil = showUntil;
        }

        public DateTime Today { get; set; }
        public DateTime ShowUntil { get; set; }
    }
}