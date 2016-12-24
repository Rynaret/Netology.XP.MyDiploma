using ShopService.Conventions.CQS.Commands;

namespace ShopService.CQS.Contexts
{
    public class RemoveProductFromSubscriptionRepositoryContext : ICommandContext
    {
        public RemoveProductFromSubscriptionRepositoryContext(long productId)
        {
            ProductId = productId;
        }

        public long ProductId { get; set; }
    }
}