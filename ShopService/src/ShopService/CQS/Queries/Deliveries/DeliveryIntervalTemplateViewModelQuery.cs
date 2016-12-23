using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopService.Conventions.CQS.Queries;
using ShopService.CQS.Criterions;
using ShopService.CQS.Criterions.DeliveryIntervals;
using ShopService.Entities;
using ShopService.Models.DeliveryIntervalTemplateViewModels;

namespace ShopService.CQS.Queries.Deliveries
{
    public class DeliveryIntervalTemplateViewModelQuery 
        : IQuery<DeliveryIntervalTemplateViewModelCriterion, DeliveryIntervalTemplateViewModel>
    {
        private readonly IQueryBuilder _queryBuilder;

        public DeliveryIntervalTemplateViewModelQuery(IQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder;
        }

        public async Task<DeliveryIntervalTemplateViewModel> AskAsync
            (DeliveryIntervalTemplateViewModelCriterion criterion)
        {
            var deliveryIntervalTemplatesCriterion = new AllDeliveryIntervalTemplatesCriterion();
            var deliveryIntervalTemplates = await _queryBuilder.For<List<DeliveryIntervalTemplate>>().
                WithAsync(deliveryIntervalTemplatesCriterion);

            if(!deliveryIntervalTemplates.Any()) 
                throw new Exception("В базе не найдено не одного шаблона доставки!");

            var selectedTemplate =
                deliveryIntervalTemplates.FirstOrDefault(x => x.Id == criterion.DeliveryIntervalTemplateId) ??
                deliveryIntervalTemplates.FirstOrDefault();
            deliveryIntervalTemplates = deliveryIntervalTemplates
                .Where(x => x.Id != selectedTemplate.Id)
                .ToList();

            return new DeliveryIntervalTemplateViewModel(selectedTemplate, deliveryIntervalTemplates);
        }
    }
}