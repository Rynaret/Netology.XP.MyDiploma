using System.Collections.Generic;
using ShopService.Conventions.CQS.Commands;
using ShopService.Entities;

namespace ShopService.CQS.Contexts
{
    public class SaveDeliveryIntervalContext : ICommandContext
    {
        public SaveDeliveryIntervalContext() { }

        public SaveDeliveryIntervalContext(DeliveryIntervalTemplate deliveryIntervalTemplate)
        {
            DeliveryIntervalTemplate = deliveryIntervalTemplate;
        }

        public DeliveryIntervalTemplate DeliveryIntervalTemplate { get; set; }
        public List<int> MonthDays { get; set; }
    }
}