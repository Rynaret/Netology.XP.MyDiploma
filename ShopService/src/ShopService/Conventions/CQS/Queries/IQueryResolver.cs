namespace ShopService.Conventions.CQS.Queries
{
    /// <summary>
    /// Динамическое получение требуемого запроса
    /// </summary>
    public interface IQueryResolver
    {
        IQuery<TCriterion, TResult> Resolve<TCriterion, TResult>() where TCriterion : ICriterion;
    }
}