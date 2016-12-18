using Autofac;
using ShopService.Conventions.CQS.Queries;

namespace ShopService.Initializers.AutofacConfigs.Resolver
{
    public class QueryForResolver : IQueryForResolver
    {
        private readonly IComponentContext _componentContext;

        public QueryForResolver(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public IQueryFor<T> Resolve<T>()
        {
            return _componentContext.Resolve<IQueryFor<T>>();
        }
    }
}