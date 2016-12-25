using System.Collections.Generic;
using System.Linq;
using ShopService.Conventions.Enums;
using ShopService.Entities;

namespace ShopService.Models.SubscriptionViewModels
{
    public class SubscriptionViewModel
    {
        public List<Product> Products { get; set; }
        public double ProductsPricesSum { get; set; }
        public DeliveryInterval DeliveryInterval { get; set; }
        public List<SubscriptionDate> SubscriptionDates { get; set; }

        public bool DeliveryIntervalExist => DeliveryInterval != null;

        public bool LastSubscriptionDateIsTypeOfStarted => SubscriptionDates
            .OrderByDescending(x => x.Date)
            .Select(x => x.Type)
            .FirstOrDefault()  == SubscriptionDateType.Start;

        public double SpentAmount { get; set; }
    }
}