using System.Collections.Generic;
using ShopService.Conventions;

namespace ShopService.Entities
{
    public class DeliveryIntervalTemplate : IEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public int DatesCountInMonth { get; set; }
        public string CronFormatMonthFrequency { get; set; }

        public ICollection<DeliveryInterval> DeliveryIntervals { get; set; }
    }
}