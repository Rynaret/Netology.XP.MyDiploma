using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopService.Conventions;
using ShopService.Conventions.CQS.Commands;
using ShopService.Conventions.Repositories;
using ShopService.CQS.Contexts;
using ShopService.Entities;

namespace ShopService.CQS.RepositoryCommands
{
    public class RemoveProductFromSubscriptionRepositoryCommand : ICommand<RemoveProductFromSubscriptionRepositoryContext>
    {
        private readonly IRepository<Product> _productRepository;

        public RemoveProductFromSubscriptionRepositoryCommand(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<CommandResult> ExecuteAsync(RemoveProductFromSubscriptionRepositoryContext commandContext)
        {
            var product = await _productRepository.Query
                .Where(x => x.Id == commandContext.ProductId)
                .FirstOrDefaultAsync();

            product.SubscriptionId = null;

            await _productRepository.SaveAsync();

            return CommandResult.Success;
        }
    }
}