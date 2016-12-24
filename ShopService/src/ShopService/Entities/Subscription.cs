using System.Collections.Generic;
using ShopService.Conventions;

namespace ShopService.Entities
{
    public class Subscription : IEntity
    {
        public long Id { get; set; }

        public long? DeliveryIntervalId { get; set; }


        public DeliveryInterval DeliveryInterval { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<SubscriptionDate> SubscriptionDates { get; set; }
    }
}