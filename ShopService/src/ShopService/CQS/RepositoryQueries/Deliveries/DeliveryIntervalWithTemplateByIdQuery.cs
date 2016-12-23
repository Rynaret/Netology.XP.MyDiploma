using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopService.Conventions.CQS.Queries;
using ShopService.Conventions.Repositories;
using ShopService.CQS.Criterions.DeliveryIntervals;
using ShopService.Entities;

namespace ShopService.CQS.RepositoryQueries.Deliveries
{
    public class DeliveryIntervalWithTemplateByIdQuery 
        : IQuery<DeliveryIntervalWithTemplateByIdCriterion, DeliveryInterval>
    {
        private readonly ILinqProvider _linqProvider;

        public DeliveryIntervalWithTemplateByIdQuery(ILinqProvider linqProvider)
        {
            _linqProvider = linqProvider;
        }

        public Task<DeliveryInterval> AskAsync(DeliveryIntervalWithTemplateByIdCriterion criterion)
        {
            return _linqProvider.Query<DeliveryInterval>()
                .Include(x => x.DeliveryIntervalTemplate)
                .Where(x => x.Id == criterion.DeliveryIntervalId)
                .FirstOrDefaultAsync();
        }
    }
}