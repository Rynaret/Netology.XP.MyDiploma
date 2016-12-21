using ShopService.Conventions.CQS.Commands;

namespace ShopService.CQS.Contexts
{
    public class AddToSubscriptionContext : ICommandContext
    {
        public AddToSubscriptionContext(long productId)
        {
            ProductId = productId;
        }

        public long ProductId { get; set; }
    }
}