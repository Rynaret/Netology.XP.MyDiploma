using System.Collections.Generic;
using ShopService.Entities;

namespace ShopService.Models.DeliveryIntervalTemplateViewModels
{
    public class DeliveryIntervalTemplateViewModel
    {
        public DeliveryIntervalTemplateViewModel(DeliveryIntervalTemplate selectedDeliveryIntervalTemplate
            , List<DeliveryIntervalTemplate> deliveryIntervalTemplates)
        {
            SelectedDeliveryIntervalTemplate = selectedDeliveryIntervalTemplate;
            DeliveryIntervalTemplates = deliveryIntervalTemplates;
        }

        public DeliveryIntervalTemplate SelectedDeliveryIntervalTemplate { get; set; }
        public List<DeliveryIntervalTemplate> DeliveryIntervalTemplates { get; set; }
    }
}