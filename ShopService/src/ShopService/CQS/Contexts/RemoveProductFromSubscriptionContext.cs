using ShopService.Conventions.CQS.Commands;

namespace ShopService.CQS.Contexts
{
    public class RemoveProductFromSubscriptionContext : ICommandContext
    {
        public RemoveProductFromSubscriptionContext(long productId)
        {
            ProductId = productId;
        }

        public long ProductId { get; set; }
    }
}