using System.Threading.Tasks;

namespace ShopService.Conventions.CQS.Commands
{
    /// <summary>
    ///     Стандартная реализация интерефейса <see cref="ICommandBuilder" />
    /// </summary>
    public class CommandBuilder : ICommandBuilder
    {
        private readonly ICommandFactory _commandFactory;
        
        public CommandBuilder(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public async Task<CommandResult> ExecuteAsync<TCommandContext>(TCommandContext commandContext)
            where TCommandContext : ICommandContext
        {
            return await _commandFactory.Create<TCommandContext>().ExecuteAsync(commandContext);
        }
    }
}