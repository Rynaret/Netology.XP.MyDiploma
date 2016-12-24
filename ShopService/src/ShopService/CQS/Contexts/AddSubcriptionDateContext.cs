using ShopService.Conventions.CQS.Commands;
using ShopService.Entities;

namespace ShopService.CQS.Contexts
{
    public class AddSubcriptionDateContext : ICommandContext
    {
        public AddSubcriptionDateContext(SubscriptionDate subscriptionDate)
        {
            SubscriptionDate = subscriptionDate;
        }

        public SubscriptionDate SubscriptionDate { get; set; }
    }
}