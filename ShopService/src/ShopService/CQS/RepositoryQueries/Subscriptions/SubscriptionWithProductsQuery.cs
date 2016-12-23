using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopService.Conventions.CQS.Queries;
using ShopService.Conventions.Repositories;
using ShopService.CQS.Criterions;
using ShopService.CQS.Criterions.Subscriptions;
using ShopService.Entities;

namespace ShopService.CQS.RepositoryQueries.Subscriptions
{
    public class SubscriptionWithProductsQuery : IQuery<SubscriptionWithProductsCriterion, Subscription>
    {
        private readonly ILinqProvider _linqProvider;

        public SubscriptionWithProductsQuery(ILinqProvider linqProvider)
        {
            _linqProvider = linqProvider;
        }

        public Task<Subscription> AskAsync(SubscriptionWithProductsCriterion criterion)
        {
            return _linqProvider.Query<Subscription>().Include(x => x.Products).FirstOrDefaultAsync();
        }
    }
}