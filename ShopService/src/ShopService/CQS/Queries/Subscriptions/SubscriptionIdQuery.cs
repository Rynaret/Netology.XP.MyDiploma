using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopService.Conventions.CQS.Queries;
using ShopService.Conventions.Repositories;
using ShopService.CQS.Criterions;
using ShopService.Entities;

namespace ShopService.CQS.Queries.Subscriptions
{
    public class SubscriptionIdQuery : IQuery<SubscriptionIdCriterion, long>
    {
        private readonly ILinqProvider _linqProvider;

        public SubscriptionIdQuery(ILinqProvider linqProvider)
        {
            _linqProvider = linqProvider;
        }

        public Task<long> AskAsync(SubscriptionIdCriterion criterion)
        {
            return _linqProvider.Query<Subscription>().Select(x => x.Id).FirstOrDefaultAsync();
        }
    }
}