﻿using ShopService.Conventions.CQS.Queries;

namespace ShopService.CQS.Criterions.DeliveryIntervals
{
    public class DeliveryIntervalTemplateByIdCriterion : ICriterion
    {
        public DeliveryIntervalTemplateByIdCriterion(long deliveryIntervalTemplateId)
        {
            DeliveryIntervalTemplateId = deliveryIntervalTemplateId;
        }

        public long DeliveryIntervalTemplateId { get; set; }
    }
}