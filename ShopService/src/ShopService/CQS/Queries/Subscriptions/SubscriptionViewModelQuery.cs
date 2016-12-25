using System.Collections.Generic;
using System.Threading.Tasks;
using ShopService.Conventions.CQS.Queries;
using ShopService.CQS.Criterions.DeliveryIntervals;
using ShopService.CQS.Criterions.Products;
using ShopService.CQS.Criterions.Subscriptions;
using ShopService.Entities;
using ShopService.Models.SubscriptionViewModels;

namespace ShopService.CQS.Queries.Subscriptions
{
    public class SubscriptionViewModelQuery : IQuery<SubscriptionViewModelCriterion, SubscriptionViewModel>
    {
        private readonly IQueryBuilder _queryBuilder;

        public SubscriptionViewModelQuery(IQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder;
        }

        public async Task<SubscriptionViewModel> AskAsync(SubscriptionViewModelCriterion criterion)
        {
            var allProductsCriterion = new AllProductsCriterion();
            var products = await _queryBuilder.For<List<Product>>().WithAsync(allProductsCriterion);

            var productsSumInSubscriptionCriterion = new CalculateProductsSumInSubscriptionCriterion();
            var sum = await _queryBuilder.For<double>().WithAsync(productsSumInSubscriptionCriterion);

            var deliveryIntervalForSubscriptionCriterion = new DeliveryIntervalWithTemplateForSubscriptionCriterion();
            var deliveryInterval = await _queryBuilder.For<DeliveryInterval>().WithAsync(deliveryIntervalForSubscriptionCriterion);

            var subscriptionDatesCriterion = new SubscriptionDatesForSubscriptionCriterion();
            var subscriptionDates = await _queryBuilder.For<List<SubscriptionDate>>().WithAsync(subscriptionDatesCriterion);

            var calculateSpentAmountCriterion = new CalculateSpentAmountCriterion(criterion.PointedTodayDate, sum);
            var spentAmount = await _queryBuilder.For<double>().WithAsync(calculateSpentAmountCriterion);

            var viewModel = new SubscriptionViewModel
            {
                Today = criterion.PointedTodayDate,
                Products = products,
                DeliveryInterval = deliveryInterval,
                SubscriptionDates = subscriptionDates,
                ProductsPricesSum = sum,
                SpentAmount = spentAmount
            };

            return viewModel;
        }
    }
}