using System;

namespace ShopService.Models.SubscriptionViewModels
{
    public class SubscriptionActiveInterval
    {
        public SubscriptionActiveInterval()
        {
        }

        public SubscriptionActiveInterval(DateTime today)
        {
            EndAt = today;
        }

        public DateTime BeginAt { get; set; }
        public DateTime EndAt { get; set; }
    }
}