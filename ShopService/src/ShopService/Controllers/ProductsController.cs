using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopService.Conventions.CQS.Queries;
using ShopService.Entities;
using ShopService.Models.Criterions;

namespace ShopService.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IQueryBuilder _queryBuilder;

        public ProductsController(IQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder;
        }

        public async Task<IActionResult> Index()
        {
            var allProductsCriterion = new AllProductsCriterion();
            var products = await _queryBuilder.For<List<Product>>().WithAsync(allProductsCriterion);
            return View(products);
        }
    }
}
