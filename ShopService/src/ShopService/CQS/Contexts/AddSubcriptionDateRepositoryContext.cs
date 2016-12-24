using ShopService.Conventions.CQS.Commands;
using ShopService.Entities;

namespace ShopService.CQS.Contexts
{
    public class AddSubcriptionDateRepositoryContext : ICommandContext
    {
        public AddSubcriptionDateRepositoryContext(SubscriptionDate subscriptionDate)
        {
            SubscriptionDate = subscriptionDate;
        }

        public SubscriptionDate SubscriptionDate { get; set; }
    }
}