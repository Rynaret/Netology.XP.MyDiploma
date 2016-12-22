using ShopService.Conventions.CQS.Queries;

namespace ShopService.CQS.Criterions
{
    public class DeliveryIntervalTemplateViewModelCriterion : ICriterion
    {
        public DeliveryIntervalTemplateViewModelCriterion(long? deliveryIntervalTemplateId)
        {
            DeliveryIntervalTemplateId = deliveryIntervalTemplateId;
        }

        public long? DeliveryIntervalTemplateId { get; set; }
    }
}