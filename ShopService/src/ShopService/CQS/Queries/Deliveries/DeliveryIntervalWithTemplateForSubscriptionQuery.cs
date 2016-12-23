using System.Threading.Tasks;
using ShopService.Conventions.CQS.Queries;
using ShopService.CQS.Criterions.DeliveryIntervals;
using ShopService.Entities;

namespace ShopService.CQS.Queries.Deliveries
{
    public class DeliveryIntervalWithTemplateForSubscriptionQuery
        : IQuery<DeliveryIntervalWithTemplateForSubscriptionCriterion, DeliveryInterval>
    {
        private readonly IQueryBuilder _queryBuilder;

        public DeliveryIntervalWithTemplateForSubscriptionQuery(IQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder;
        }

        public async Task<DeliveryInterval> AskAsync(DeliveryIntervalWithTemplateForSubscriptionCriterion criterion)
        {
            var deliveryIntervalIdCriterion = new SubscriptionDeliveryIntervalIdCriterion();
            var deliveryIntervalId = await _queryBuilder.For<long?>().WithAsync(deliveryIntervalIdCriterion);

            if (!deliveryIntervalId.HasValue) return null;

            var deliveryIntervalByIdCriterion = new DeliveryIntervalWithTemplateByIdCriterion(deliveryIntervalId.Value);
            return await _queryBuilder.For<DeliveryInterval>().WithAsync(deliveryIntervalByIdCriterion);
        }
    }
}