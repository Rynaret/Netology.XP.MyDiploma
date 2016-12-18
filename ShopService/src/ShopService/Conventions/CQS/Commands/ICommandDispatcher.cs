using System.Threading.Tasks;

namespace ShopService.Conventions.CQS.Commands
{
    /// <summary>
    /// Диспетчер комманд. Занимается отправкой комманд (в очередь сообщений) на выполнение
    /// </summary>
    public interface ICommandDispatcher
    {
        /// <summary>
        /// Отправить команду на выполнение
        /// </summary>
        /// <typeparam name="TCommandContext">тип контекста команды</typeparam>
        /// <param name="commandContext">контекст команды</param>
        Task DispatchAsync<TCommandContext>(TCommandContext commandContext) 
            where TCommandContext : ICommandContext;
    }
}