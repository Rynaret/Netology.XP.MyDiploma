namespace ShopService.Conventions.CQS.Queries
{
    public class QueryBuilder : IQueryBuilder
    {
        private readonly IQueryForResolver _queryForResolver;
        public QueryBuilder(IQueryForResolver queryForResolver)
        {
            _queryForResolver = queryForResolver;
        }

        public IQueryFor<TResult> For<TResult>()
        {
            return _queryForResolver.Resolve<TResult>();
        }
    }
}