using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopService.Conventions.CQS.Queries;
using ShopService.Conventions.Repositories;
using ShopService.Entities;
using ShopService.Models.Criterions;

namespace ShopService.Queries.Products
{
    public class AllProductsQuery : IQuery<AllProductsCriterion, List<Product>>
    {
        private readonly ILinqProvider _linqProvider;

        public AllProductsQuery(ILinqProvider linqProvider)
        {
            _linqProvider = linqProvider;
        }

        public Task<List<Product>> AskAsync(AllProductsCriterion criterion)
        {
            return _linqProvider.Query<Product>()
                .ToListAsync();
        }
    }
}