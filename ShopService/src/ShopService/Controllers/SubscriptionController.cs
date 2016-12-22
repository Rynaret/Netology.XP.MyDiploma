using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopService.Conventions.CQS.Commands;
using ShopService.Conventions.CQS.Queries;
using ShopService.CQS.Contexts;
using ShopService.CQS.Criterions;
using ShopService.Entities;
using ShopService.Models.SubscriptionViewModels;

namespace ShopService.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly IQueryBuilder _queryBuilder;
        private readonly ICommandBuilder _commandBuilder;

        public SubscriptionController(IQueryBuilder queryBuilder, ICommandBuilder commandBuilder)
        {
            _queryBuilder = queryBuilder;
            _commandBuilder = commandBuilder;
        }

        public async Task<IActionResult> Index()
        {
            var allProductsCriterion = new AllProductsCriterion();
            var products = await _queryBuilder.For<List<Product>>().WithAsync(allProductsCriterion);

            var productsSumInSubscriptionCriterion = new CalculateProductsSumInSubscriptionCriterion();
            var sum = await _queryBuilder.For<double>().WithAsync(productsSumInSubscriptionCriterion);

            var deliveryIntervalTemplatesCriterion = new AllDeliveryIntervalTemplatesCriterion();
            var deliveryIntervalTemplates = await _queryBuilder.For<List<DeliveryIntervalTemplate>>().
                WithAsync(deliveryIntervalTemplatesCriterion);

            var viewModel = new SubscriptionViewModel(products, sum, deliveryIntervalTemplates);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddToSubscription(long id)
        {
            var addToSubscriptionContext = new AddToSubscriptionContext(id);
            await _commandBuilder.ExecuteAsync(addToSubscriptionContext);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromSubscription(long id)
        {
            var removeFromSubscriptionContext = new RemoveFromSubscriptionContext(id);
            await _commandBuilder.ExecuteAsync(removeFromSubscriptionContext);

            return RedirectToAction("Index");
        }
    }
}
