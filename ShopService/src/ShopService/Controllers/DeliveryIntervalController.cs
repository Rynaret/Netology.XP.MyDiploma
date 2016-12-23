using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopService.Conventions.CQS.Commands;
using ShopService.Conventions.CQS.Queries;
using ShopService.CQS.Contexts;
using ShopService.CQS.Criterions;
using ShopService.CQS.Criterions.DeliveryIntervals;
using ShopService.Models.DeliveryIntervalTemplateViewModels;

namespace ShopService.Controllers
{
    public class DeliveryIntervalController : Controller
    {
        private readonly IQueryBuilder _queryBuilder;
        private readonly ICommandBuilder _commandBuilder;

        public DeliveryIntervalController(IQueryBuilder queryBuilder, ICommandBuilder commandBuilder)
        {
            _queryBuilder = queryBuilder;
            _commandBuilder = commandBuilder;
        }

        public async Task<IActionResult> Index(long? id)
        {
            var deliveryIntervalTemplateViewModelCriterion = new DeliveryIntervalTemplateViewModelCriterion(id);
            var viewModel = await _queryBuilder.For<DeliveryIntervalTemplateViewModel>().
                WithAsync(deliveryIntervalTemplateViewModelCriterion);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SaveDeliveryInterval(SaveDeliveryIntervalContext context)
        {
            var commandResult = await _commandBuilder.ExecuteAsync(context);

            if(commandResult.IsDone) return RedirectToAction("Index", "Subscription");

            return RedirectToAction("Index", context.DeliveryIntervalTemplate.Id);
        }
    }
}
