using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopService.Conventions;
using ShopService.Entities;

namespace ShopService.Initializers
{
    public class DeliveryIntervalTemplatesInitializer : IInitializable
    {
        private readonly DbContext _dbContext;

        public DeliveryIntervalTemplatesInitializer(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Order => 4;
        public void Initialize()
        {
            var deliveryIntervalTemplateNamesInDb = _dbContext.Set<DeliveryIntervalTemplate>()
                .Select(x => x.Name)
                .ToList();
            var deliveryIntervals = new List<DeliveryIntervalTemplate>
            {
                new DeliveryIntervalTemplate
                {
                    Name = "Раз в два месяца",
                    DatesCountInMonth = 1,
                    CronFormatMonthFrequency = "1/2"
                },
                new DeliveryIntervalTemplate
                {
                    Name = "Раз в месяц",
                    DatesCountInMonth = 1,
                    CronFormatMonthFrequency = "1/1"
                },
                new DeliveryIntervalTemplate
                {
                    Name = "Два раза в месяц",
                    DatesCountInMonth = 2,
                    CronFormatMonthFrequency = "1/1"
                }
            };
            var deliveryIntervalsToAdd = deliveryIntervals
                .Where(x => !deliveryIntervalTemplateNamesInDb.Contains(x.Name))
                .ToList();

            _dbContext.Set<DeliveryIntervalTemplate>().AddRange(deliveryIntervalsToAdd);
            _dbContext.SaveChanges();
        }
    }
}