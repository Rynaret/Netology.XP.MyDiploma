using System.Collections.Generic;
using ShopService.Entities;

namespace ShopService.Models.SubscriptionViewModels
{
    public class SubscriptionViewModel
    {
        public SubscriptionViewModel(List<Product> products, double productsPricesSum
            , List<DeliveryIntervalTemplate> deliveryIntervalTemplates)
        {
            Products = products;
            ProductsPricesSum = productsPricesSum;
            DeliveryIntervalTemplates = deliveryIntervalTemplates;
        }

        public List<Product> Products { get; set; }
        public double ProductsPricesSum { get; set; }
        public List<DeliveryIntervalTemplate> DeliveryIntervalTemplates { get; set; }
    }
}