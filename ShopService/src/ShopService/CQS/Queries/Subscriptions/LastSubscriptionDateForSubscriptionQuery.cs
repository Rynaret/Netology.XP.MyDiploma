using System.Threading.Tasks;
using ShopService.Conventions.CQS.Queries;
using ShopService.CQS.Criterions.Subscriptions;
using ShopService.Entities;

namespace ShopService.CQS.Queries.Subscriptions
{
    public class LastSubscriptionDateForSubscriptionQuery 
        : IQuery<LastSubscriptionDateForSubscriptionCriterion, SubscriptionDate>
    {
        private readonly IQueryBuilder _queryBuilder;

        public LastSubscriptionDateForSubscriptionQuery(IQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder;
        }

        public async Task<SubscriptionDate> AskAsync(LastSubscriptionDateForSubscriptionCriterion criterion)
        {
            var subscriptionIdCriterion = new SubscriptionIdCriterion();
            var subscriptionId = await _queryBuilder.For<long>().WithAsync(subscriptionIdCriterion);

            var repositoryCriterion = new LastSubscriptionDateForSubscriptionRepositoryCriterion(subscriptionId);
            return await _queryBuilder.For<SubscriptionDate>().WithAsync(repositoryCriterion);
        }
    }
}