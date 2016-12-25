using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using ShopService.Conventions.Enums;
using ShopService.Entities;

namespace ShopService.Models.SubscriptionViewModels
{
    public class SubscriptionViewModel
    {
        public DateTime Today { get; set; }

        public List<Product> Products { get; set; }
        public double ProductsPricesSum { get; set; }
        public DeliveryInterval DeliveryInterval { get; set; }
        public List<SubscriptionDate> SubscriptionDates { get; set; }
        public List<DateTime> DeliveryDates { get; set; }

        public string SubscriptionDatesString
        {
            get
            {
                var result = new StringBuilder();
                foreach (var subscriptionDate in SubscriptionDates)
                {
                    result.Append(subscriptionDate.Type.GetAttribute<DisplayAttribute>()?.GetName() ?? "");
                    result.AppendLine(subscriptionDate.Date.ToString(" - dd.MM.yyyy<br/>"));
                }
                return result.ToString();
            }
        }

        public bool DeliveryIntervalExist => DeliveryInterval != null;
        public bool LastSubscriptionDateIsTypeOfStarted => SubscriptionDates
            .Where(x => x.Date <= Today)
            .OrderByDescending(x => x.Date)
            .Select(x => x.Type)
            .FirstOrDefault()  == SubscriptionDateType.Start;

        public double SpentAmount { get; set; }
    }
}