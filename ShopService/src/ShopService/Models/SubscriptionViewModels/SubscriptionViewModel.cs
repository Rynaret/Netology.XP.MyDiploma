using System.Collections.Generic;
using ShopService.Entities;

namespace ShopService.Models.SubscriptionViewModels
{
    public class SubscriptionViewModel
    {
        public SubscriptionViewModel(List<Product> products, double productsPricesSum)
        {
            Products = products;
            ProductsPricesSum = productsPricesSum;
        }

        public List<Product> Products { get; set; }
        public double ProductsPricesSum { get; set; }
    }
}