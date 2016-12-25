using System;

namespace ShopService.Models.SubscriptionViewModels
{
    public class SubscriptionActiveInterval
    {
        public SubscriptionActiveInterval()
        {
        }

        public SubscriptionActiveInterval(DateTime endAt)
        {
            EndAt = endAt;
        }

        public DateTime BeginAt { get; set; }
        public DateTime EndAt { get; set; }
    }
}