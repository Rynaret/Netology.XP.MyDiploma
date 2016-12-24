using ShopService.Conventions.CQS.Queries;

namespace ShopService.CQS.Criterions.Subscriptions
{
    public class LastSubscriptionDateForSubscriptionRepositoryCriterion : ICriterion
    {
        public LastSubscriptionDateForSubscriptionRepositoryCriterion(long subscriptionId)
        {
            SubscriptionId = subscriptionId;
        }

        public long SubscriptionId { get; set; }
    }
}