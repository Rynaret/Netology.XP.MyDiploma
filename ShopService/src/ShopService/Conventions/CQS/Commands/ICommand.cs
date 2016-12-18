using System.Threading.Tasks;

namespace ShopService.Conventions.CQS.Commands
{
    /// <summary>
    ///     Интерфейс для команды.
    /// </summary>
    /// <typeparam name="TCommandContext">Контекст команды</typeparam>
    public interface ICommand<in TCommandContext> 
        where TCommandContext : ICommandContext
    {
        /// <summary>
        ///     Выполняет действия команды.
        /// </summary>
        /// <param name="commandContext">Контекст команды</param>
        Task<CommandResult> ExecuteAsync(TCommandContext commandContext);
    }
}