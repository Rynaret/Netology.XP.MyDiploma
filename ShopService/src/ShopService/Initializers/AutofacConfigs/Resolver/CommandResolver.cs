using Autofac;
using ShopService.Conventions.CQS.Commands;

namespace ShopService.Initializers.AutofacConfigs.Resolver
{
    public class CommandResolver : ICommandResolver
    {
        private readonly IComponentContext _componentContext;
        public CommandResolver(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public ICommand<TCommandContext> Resolve<TCommandContext>() 
            where TCommandContext : ICommandContext
        {
            return _componentContext.Resolve<ICommand<TCommandContext>>();
        }
    }
}