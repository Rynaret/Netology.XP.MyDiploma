using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopService.Conventions.CQS.Commands;
using ShopService.Conventions.CQS.Queries;
using ShopService.CQS.Contexts;
using ShopService.CQS.Criterions.DeliveryIntervals;
using ShopService.CQS.Criterions.Products;
using ShopService.CQS.Criterions.Subscriptions;
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

        public async Task<IActionResult> Index(string error)
        {
            var subscriptionViewModelCriterion = new SubscriptionViewModelCriterion();
            var viewModel = await _queryBuilder.For<SubscriptionViewModel>().WithAsync(subscriptionViewModelCriterion);

            if(!string.IsNullOrWhiteSpace(error)) ModelState.AddModelError(string.Empty, error);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddToSubscription(long id)
        {
            var addToSubscriptionContext = new AddToSubscriptionContext(id);
            var commandResult = await _commandBuilder.ExecuteAsync(addToSubscriptionContext);

            return RedirectToAction("Index", routeValues: commandResult.Message);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromSubscription(long id)
        {
            var removeFromSubscriptionContext = new RemoveProductFromSubscriptionContext(id);
            var commandResult = await _commandBuilder.ExecuteAsync(removeFromSubscriptionContext);

            return RedirectToAction("Index", routeValues: commandResult.Message);
        }

        [HttpPost]
        public async Task<IActionResult> SuspendResumeSubscription()
        {
            var commandContext = new SuspendResumeSubscriptionContext();
            var commandResult = await _commandBuilder.ExecuteAsync(commandContext);

            return RedirectToAction("Index", routeValues: commandResult.Message);
        }
    }
}
