using ShopService.Conventions.CQS.Commands;

namespace ShopService.CQS.Contexts
{
    public class AddToSubscriptionRepositoryContext : ICommandContext
    {
        public AddToSubscriptionRepositoryContext(long productId, long subscriptionId)
        {
            ProductId = productId;
            SubscriptionId = subscriptionId;
        }

        public long ProductId { get; set; }
        public long SubscriptionId { get; set; }
    }
}