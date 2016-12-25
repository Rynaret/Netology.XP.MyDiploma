using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopService.Conventions.CQS.Queries;
using ShopService.Conventions.Repositories;
using ShopService.CQS.Criterions.DeliveryIntervals;
using ShopService.Entities;

namespace ShopService.CQS.RepositoryQueries.Deliveries
{
    public class DeliveryIntervalTemplateByIdQuery : IQuery<DeliveryIntervalTemplateByIdCriterion, DeliveryIntervalTemplate>
    {
        private readonly ILinqProvider _linqProvider;

        public DeliveryIntervalTemplateByIdQuery(ILinqProvider linqProvider)
        {
            _linqProvider = linqProvider;
        }

        public Task<DeliveryIntervalTemplate> AskAsync(DeliveryIntervalTemplateByIdCriterion criterion)
        {
            return _linqProvider.Query<DeliveryIntervalTemplate>()
                    .FirstOrDefaultAsync(x => x.Id == criterion.DeliveryIntervalTemplateId);
        }
    }
}