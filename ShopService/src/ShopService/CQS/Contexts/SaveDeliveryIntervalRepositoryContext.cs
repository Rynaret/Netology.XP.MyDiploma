using ShopService.Conventions.CQS.Commands;
using ShopService.Entities;

namespace ShopService.CQS.Contexts
{
    public class SaveDeliveryIntervalRepositoryContext : ICommandContext
    {
        public SaveDeliveryIntervalRepositoryContext(DeliveryInterval deliveryInterval)
        {
            DeliveryInterval = deliveryInterval;
        }

        public DeliveryInterval DeliveryInterval { get; set; }
    }
}