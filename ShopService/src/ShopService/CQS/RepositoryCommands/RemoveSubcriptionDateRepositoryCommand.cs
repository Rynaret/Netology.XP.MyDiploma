using System.Threading.Tasks;
using ShopService.Conventions;
using ShopService.Conventions.CQS.Commands;
using ShopService.Conventions.Repositories;
using ShopService.CQS.Contexts;
using ShopService.Entities;

namespace ShopService.CQS.RepositoryCommands
{
    public class RemoveSubcriptionDateRepositoryCommand : ICommand<RemoveSubcriptionDateRepositoryContext>
    {
        private readonly IRepository<SubscriptionDate> _subscriptionDateRepository;

        public RemoveSubcriptionDateRepositoryCommand(IRepository<SubscriptionDate> subscriptionDateRepository)
        {
            _subscriptionDateRepository = subscriptionDateRepository;
        }

        public async Task<CommandResult> ExecuteAsync(RemoveSubcriptionDateRepositoryContext commandContext)
        {
            _subscriptionDateRepository.Delete(commandContext.SubscriptionDate);
            await _subscriptionDateRepository.SaveAsync();
            return CommandResult.Success;
        }
    }
}