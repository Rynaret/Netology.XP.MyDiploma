using ShopService.Conventions.CQS.Commands;

namespace ShopService.CQS.Contexts
{
    public class RemoveFromSubscriptionRepositoryContext : ICommandContext
    {
        public RemoveFromSubscriptionRepositoryContext(long productId)
        {
            ProductId = productId;
        }

        public long ProductId { get; set; }
    }
}