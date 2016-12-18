using System.Threading.Tasks;

namespace ShopService.Conventions.CQS.Commands
{
    /// <summary>
    /// Исполнитель команд, выполняет требуемую задачу
    /// </summary>
    public interface ICommandRunner
    {
        /// <summary>
        /// Выполняет комманду
        /// </summary>
        /// <typeparam name="TCommandContext">тип контекста команды</typeparam>
        /// <param name="commandContext">контекст команды</param>
        Task RunAsync<TCommandContext>(TCommandContext commandContext)
            where TCommandContext : ICommandContext;
    }
}