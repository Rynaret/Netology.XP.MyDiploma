using NCrontab.Advanced;
using NCrontab.Advanced.Enumerations;
using ShopService.Conventions;
using ShopService.Conventions.Extensions;

namespace ShopService.Entities
{
    public class DeliveryInterval : IEntity
    {
        public long Id { get; set; }

        public string CronString { get; set; }
        public long DeliveryIntervalTemplateId { get; set; }

        public DeliveryIntervalTemplate DeliveryIntervalTemplate { get; set; }

        public string SelectedDays => CronString.GetDays();
    }
}