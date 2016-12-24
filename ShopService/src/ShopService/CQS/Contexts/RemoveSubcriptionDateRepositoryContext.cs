using ShopService.Conventions.CQS.Commands;
using ShopService.Entities;

namespace ShopService.CQS.Contexts
{
    public class RemoveSubcriptionDateRepositoryContext : ICommandContext
    {
        public RemoveSubcriptionDateRepositoryContext(SubscriptionDate subscriptionDate)
        {
            SubscriptionDate = subscriptionDate;
        }

        public SubscriptionDate SubscriptionDate { get; set; }
    }
}