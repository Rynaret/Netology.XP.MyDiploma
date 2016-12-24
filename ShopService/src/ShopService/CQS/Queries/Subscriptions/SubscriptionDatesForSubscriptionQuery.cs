using System.Collections.Generic;
using System.Threading.Tasks;
using ShopService.Conventions.CQS.Queries;
using ShopService.CQS.Criterions.Subscriptions;
using ShopService.Entities;

namespace ShopService.CQS.Queries.Subscriptions
{
    public class SubscriptionDatesForSubscriptionQuery
        : IQuery<SubscriptionDatesForSubscriptionCriterion, List<SubscriptionDate>>
    {
        private readonly IQueryBuilder _queryBuilder;

        public SubscriptionDatesForSubscriptionQuery(IQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder;
        }

        public async Task<List<SubscriptionDate>> AskAsync(SubscriptionDatesForSubscriptionCriterion criterion)
        {
            var subscriptionIdCriterion = new SubscriptionIdCriterion();
            var subscriptionId = await _queryBuilder.For<long>().WithAsync(subscriptionIdCriterion);

            var repositoryCriterion = new SubscriptionDatesForSubscriptionRepositoryCriterion(subscriptionId);
            return await _queryBuilder.For<List<SubscriptionDate>>().WithAsync(repositoryCriterion);
        }
    }
}