using Autofac;
using ShopService.Conventions.CQS.Queries;

namespace ShopService.Initializers.AutofacConfigs.Resolver
{
    public class QueryResolver : IQueryResolver
    {
        private readonly IComponentContext _componentContext;
        public QueryResolver(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public IQuery<TCriterion, TResult> Resolve<TCriterion, TResult>() 
            where TCriterion : ICriterion
        {
            return _componentContext.Resolve<IQuery<TCriterion, TResult>>();
        }
    }
}