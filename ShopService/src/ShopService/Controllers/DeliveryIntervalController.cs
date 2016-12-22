using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopService.Conventions.CQS.Queries;
using ShopService.CQS.Criterions;
using ShopService.Entities;
using ShopService.Models.DeliveryIntervalTemplateViewModels;

namespace ShopService.Controllers
{
    public class DeliveryIntervalController : Controller
    {
        private readonly IQueryBuilder _queryBuilder;

        public DeliveryIntervalController(IQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder;
        }

        public async Task<IActionResult> Index(long? id)
        {
            var deliveryIntervalTemplatesCriterion = new AllDeliveryIntervalTemplatesCriterion();
            var deliveryIntervalTemplates = await _queryBuilder.For<List<DeliveryIntervalTemplate>>().
                WithAsync(deliveryIntervalTemplatesCriterion);

            var selectedTemplate = deliveryIntervalTemplates.FirstOrDefault(x => x.Id == id) ??
                                   deliveryIntervalTemplates.FirstOrDefault();
            deliveryIntervalTemplates = deliveryIntervalTemplates
                .Where(x => x.Id != selectedTemplate.Id)
                .ToList();

            var viewModel = new DeliveryIntervalTemplateViewModel(selectedTemplate, deliveryIntervalTemplates);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SaveDeliveryInterval(DeliveryIntervalEditModel model)
        {
            return RedirectToAction("Index", "Subscription");
        }
    }
}
