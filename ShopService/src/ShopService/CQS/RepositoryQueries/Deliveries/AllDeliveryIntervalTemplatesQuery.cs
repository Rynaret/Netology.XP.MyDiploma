using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopService.Conventions.CQS.Queries;
using ShopService.Conventions.Repositories;
using ShopService.CQS.Criterions;
using ShopService.CQS.Criterions.DeliveryIntervals;
using ShopService.Entities;

namespace ShopService.CQS.RepositoryQueries.Deliveries
{
    public class AllDeliveryIntervalTemplatesQuery : IQuery<AllDeliveryIntervalTemplatesCriterion, List<DeliveryIntervalTemplate>>
    {
        private readonly ILinqProvider _linqProvider;

        public AllDeliveryIntervalTemplatesQuery(ILinqProvider linqProvider)
        {
            _linqProvider = linqProvider;
        }

        public Task<List<DeliveryIntervalTemplate>> AskAsync(AllDeliveryIntervalTemplatesCriterion criterion)
        {
            return _linqProvider.Query<DeliveryIntervalTemplate>().ToListAsync();
        }
    }
}