using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopService.Conventions.CQS.Queries;
using ShopService.Conventions.Repositories;
using ShopService.CQS.Criterions.DeliveryIntervals;
using ShopService.Entities;

namespace ShopService.CQS.RepositoryQueries.Subscriptions
{
    public class SubscriptionDeliveryIntervalIdQuery : IQuery<SubscriptionDeliveryIntervalIdCriterion, long?>
    {
        private readonly ILinqProvider _linqProvider;

        public SubscriptionDeliveryIntervalIdQuery(ILinqProvider linqProvider)
        {
            _linqProvider = linqProvider;
        }

        public Task<long?> AskAsync(SubscriptionDeliveryIntervalIdCriterion criterion)
        {
            return _linqProvider.Query<Subscription>()
                .Select(x => x.DeliveryIntervalId)
                .FirstOrDefaultAsync();
        }
    }
}