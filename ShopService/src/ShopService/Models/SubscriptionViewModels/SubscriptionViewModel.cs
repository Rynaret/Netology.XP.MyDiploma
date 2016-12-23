using System.Collections.Generic;
using ShopService.Entities;

namespace ShopService.Models.SubscriptionViewModels
{
    public class SubscriptionViewModel
    {
        public SubscriptionViewModel(List<Product> products, double productsPricesSum, DeliveryInterval deliveryInterval)
        {
            Products = products;
            ProductsPricesSum = productsPricesSum;
            DeliveryInterval = deliveryInterval;
        }

        public List<Product> Products { get; set; }
        public double ProductsPricesSum { get; set; }
        public DeliveryInterval DeliveryInterval { get; set; }

        public bool DeliveryIntervalExist => DeliveryInterval != null;
    }
}