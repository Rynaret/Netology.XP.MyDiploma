using System;
using System.Threading.Tasks;
using ShopService.Conventions;
using ShopService.Conventions.CQS.Commands;
using ShopService.Conventions.CQS.Queries;
using ShopService.Conventions.Enums;
using ShopService.CQS.Contexts;
using ShopService.CQS.Criterions.Subscriptions;
using ShopService.Entities;

namespace ShopService.CQS.Commands
{
    public class SuspendResumeSubscriptionCommand 
        : ICommand<SuspendResumeSubscriptionContext>
    {
        private readonly IQueryBuilder _queryBuilder;
        private readonly ICommandBuilder _commandBuilder;

        public SuspendResumeSubscriptionCommand(IQueryBuilder queryBuilder, ICommandBuilder commandBuilder)
        {
            _queryBuilder = queryBuilder;
            _commandBuilder = commandBuilder;
        }

        public async Task<CommandResult> ExecuteAsync(SuspendResumeSubscriptionContext commandContext)
        {
            var today = DateTime.UtcNow;

            var subscriptionIdCriterion = new SubscriptionIdCriterion();
            var subscriptionId = await _queryBuilder.For<long>().WithAsync(subscriptionIdCriterion);

            var lastSubscriptionDateCriterion = new LastSubscriptionDateForSubscriptionRepositoryCriterion(subscriptionId);
            var lastSubscriptionDate = await _queryBuilder.For<SubscriptionDate>().WithAsync(lastSubscriptionDateCriterion);

            var newSubscriptionDate = new SubscriptionDate
            {
                Date = DateTime.UtcNow,
                SubscriptionId = subscriptionId,
            };

            if (lastSubscriptionDate != null)
            {
                var lastSubscriptionDateIsToday = lastSubscriptionDate.Date.Date == today.Date;

                if (lastSubscriptionDateIsToday)
                {
                    var removeSubscriptionDateContext = new RemoveSubcriptionDateRepositoryContext(lastSubscriptionDate);
                    return await _commandBuilder.ExecuteAsync(removeSubscriptionDateContext);
                }

                newSubscriptionDate.Type = lastSubscriptionDate.Type == SubscriptionDateType.Start
                    ? SubscriptionDateType.Suspend
                    : SubscriptionDateType.Start;
            }
            else newSubscriptionDate.Type = SubscriptionDateType.Start;

            var addSubscriptionDateContext = new AddSubcriptionDateRepositoryContext(newSubscriptionDate);
            return await _commandBuilder.ExecuteAsync(addSubscriptionDateContext);
        }
    }
}