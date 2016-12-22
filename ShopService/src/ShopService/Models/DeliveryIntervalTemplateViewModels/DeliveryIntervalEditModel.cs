using System.Collections.Generic;
using ShopService.Entities;

namespace ShopService.Models.DeliveryIntervalTemplateViewModels
{
    public class DeliveryIntervalEditModel
    {
        public DeliveryIntervalEditModel(){}

        public DeliveryIntervalEditModel(DeliveryIntervalTemplate deliveryIntervalTemplate)
        {
            DeliveryIntervalTemplate = deliveryIntervalTemplate;
        }

        public DeliveryIntervalTemplate DeliveryIntervalTemplate { get; set; }
        public List<int> MonthDays { get; set; }
    }
}