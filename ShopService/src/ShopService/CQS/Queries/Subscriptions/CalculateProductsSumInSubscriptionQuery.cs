using System.Threading.Tasks;
using ShopService.Conventions.CQS.Queries;
using ShopService.CQS.Criterions;
using ShopService.Entities;

namespace ShopService.CQS.Queries.Subscriptions
{
    public class CalculateProductsSumInSubscriptionQuery : IQuery<CalculateProductsSumInSubscriptionCriterion, double>
    {
        private readonly IQueryBuilder _queryBuilder;

        public CalculateProductsSumInSubscriptionQuery(IQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder;
        }

        public async Task<double> AskAsync(CalculateProductsSumInSubscriptionCriterion criterion)
        {
            var subscriptionWithProductsCriterion = new SubscriptionWithProductsCriterion();
            var subscriptionWithProducts = await _queryBuilder.For<Subscription>().WithAsync(subscriptionWithProductsCriterion);

            double sum = 0;

            foreach (var product in subscriptionWithProducts.Products)
            {
                sum += product.Price;
            }

            return sum;
        }
    }
}