﻿using ShopService.Conventions;

namespace ShopService.Entities
{
    public class DeliveryInterval : IEntity
    {
        public long Id { get; set; }

        public string CronString { get; set; }
        public long DeliveryIntervalTemplateId { get; set; }

        public DeliveryIntervalTemplate DeliveryIntervalTemplate { get; set; }
    }
}