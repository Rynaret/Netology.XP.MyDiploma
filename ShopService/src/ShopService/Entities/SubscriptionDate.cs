using System;
using ShopService.Conventions;
using ShopService.Conventions.Enums;

namespace ShopService.Entities
{
    public class SubscriptionDate : IEntity
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }
        public SubscriptionDateType Type { get; set; }
        public long SubscriptionId { get; set; }

        public Subscription Subscription { get; set; }
    }
}