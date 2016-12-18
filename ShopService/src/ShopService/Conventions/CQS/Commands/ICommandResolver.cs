namespace ShopService.Conventions.CQS.Commands
{
    /// <summary>
    /// Динамическое получение требуемой команды
    /// </summary>
    public interface ICommandResolver
    {
        ICommand<TCommandContext> Resolve<TCommandContext>()
            where TCommandContext : ICommandContext;
    }
}