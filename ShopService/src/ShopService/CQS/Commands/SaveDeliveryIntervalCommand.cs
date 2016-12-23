using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopService.Conventions;
using ShopService.Conventions.CQS.Commands;
using ShopService.Conventions.CQS.Queries;
using ShopService.CQS.Contexts;
using ShopService.CQS.Criterions;
using ShopService.CQS.Criterions.DeliveryIntervals;
using ShopService.Entities;

namespace ShopService.CQS.Commands
{
    public class SaveDeliveryIntervalCommand : ICommand<SaveDeliveryIntervalContext>
    {
        private readonly IQueryBuilder _queryBuilder;
        private readonly ICommandBuilder _commandBuilder;

        public SaveDeliveryIntervalCommand(IQueryBuilder queryBuilder, ICommandBuilder commandBuilder)
        {
            _queryBuilder = queryBuilder;
            _commandBuilder = commandBuilder;
        }

        public async Task<CommandResult> ExecuteAsync(SaveDeliveryIntervalContext commandContext)
        {
            var templateByIdCriterion = new DeliveryIntervalTemplateByIdCriterion(commandContext.DeliveryIntervalTemplate.Id);
            var template = await _queryBuilder.For<DeliveryIntervalTemplate>().WithAsync(templateByIdCriterion);

            if (template == null) throw new Exception("Шаблон доставки не найден!");

            var cronDaysString = BuildCronDaysString(commandContext.MonthDays);
            var cronFormatMonthFrequency = template.CronFormatMonthFrequency;
            var cronMonthString = cronFormatMonthFrequency.Substring(1, cronFormatMonthFrequency.Length - 1);
            cronMonthString = $"{DateTime.Today.Month}{cronMonthString}";
            var delivery = new DeliveryInterval
            {
                DeliveryIntervalTemplateId = commandContext.DeliveryIntervalTemplate.Id,
                CronString = $"0 0 0 {cronDaysString} {cronMonthString} *"
            };

            var repositoryContext = new SaveDeliveryIntervalRepositoryContext(delivery);
            return await _commandBuilder.ExecuteAsync(repositoryContext);
        }

        private string BuildCronDaysString(List<int> monthDays)
        {
            var cronDaysStringBuilder = new StringBuilder();
            var last = monthDays.Last();
            foreach (var monthDay in monthDays)
            {
                cronDaysStringBuilder.Append(monthDay);
                if (!monthDay.Equals(last)) cronDaysStringBuilder.Append(',');
            }

            return cronDaysStringBuilder.ToString();
        }
    }
}