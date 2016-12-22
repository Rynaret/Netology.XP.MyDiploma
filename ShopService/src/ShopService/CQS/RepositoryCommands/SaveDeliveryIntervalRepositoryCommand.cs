using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopService.Conventions;
using ShopService.Conventions.CQS.Commands;
using ShopService.Conventions.Repositories;
using ShopService.CQS.Contexts;
using ShopService.Entities;

namespace ShopService.CQS.RepositoryCommands
{
    public class SaveDeliveryIntervalRepositoryCommand : ICommand<SaveDeliveryIntervalRepositoryContext>
    {
        private readonly IRepository<Subscription> _subscriptionRepository;
        private readonly IRepository<DeliveryInterval> _deliveryIntervalRepository;

        public SaveDeliveryIntervalRepositoryCommand(IRepository<Subscription> subscriptionRepository
            , IRepository<DeliveryInterval> deliveryIntervalRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _deliveryIntervalRepository = deliveryIntervalRepository;
        }

        public async Task<CommandResult> ExecuteAsync(SaveDeliveryIntervalRepositoryContext commandContext)
        {
            var entity = await _subscriptionRepository.Query.FirstOrDefaultAsync();

            _deliveryIntervalRepository.Add(commandContext.DeliveryInterval);
            await _deliveryIntervalRepository.SaveAsync();

            entity.DeliveryIntervalId = commandContext.DeliveryInterval.Id;
            await _subscriptionRepository.SaveAsync();

            return CommandResult.Success;
        }
    }
}