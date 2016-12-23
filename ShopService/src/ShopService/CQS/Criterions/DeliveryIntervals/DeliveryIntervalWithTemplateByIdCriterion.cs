using ShopService.Conventions.CQS.Queries;

namespace ShopService.CQS.Criterions.DeliveryIntervals
{
    public class DeliveryIntervalWithTemplateByIdCriterion : ICriterion
    {
        public DeliveryIntervalWithTemplateByIdCriterion(long deliveryIntervalId)
        {
            DeliveryIntervalId = deliveryIntervalId;
        }

        public long DeliveryIntervalId { get; set; }
    }
}