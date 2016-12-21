using ShopService.Conventions.CQS.Commands;

namespace ShopService.CQS.Contexts
{
    public class RemoveFromSubscriptionContext : ICommandContext
    {
        public RemoveFromSubscriptionContext(long productId)
        {
            ProductId = productId;
        }

        public long ProductId { get; set; }
    }
}