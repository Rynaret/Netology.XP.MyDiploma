using System.Threading.Tasks;
using ShopService.Conventions;
using ShopService.Conventions.CQS.Commands;
using ShopService.CQS.Contexts;

namespace ShopService.CQS.Commands
{
    public class RemoveFromSubscriptionCommand : ICommand<RemoveFromSubscriptionContext>
    {
        private readonly ICommandBuilder _commandBuilder;

        public RemoveFromSubscriptionCommand(ICommandBuilder commandBuilder)
        {
            _commandBuilder = commandBuilder;
        }

        public Task<CommandResult> ExecuteAsync(RemoveFromSubscriptionContext commandContext)
        {
            var repoContext = new RemoveFromSubscriptionRepositoryContext(commandContext.ProductId);
            return _commandBuilder.ExecuteAsync(repoContext);
        }
    }
}