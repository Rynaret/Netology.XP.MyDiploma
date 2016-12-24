using ShopService.Conventions.CQS.Queries;

namespace ShopService.CQS.Criterions.Subscriptions
{
    public class SubscriptionDatesForSubscriptionRepositoryCriterion : ICriterion
    {
        public SubscriptionDatesForSubscriptionRepositoryCriterion(long subscriptionId)
        {
            SubscriptionId = subscriptionId;
        }

        public long SubscriptionId { get; set; }
    }
}