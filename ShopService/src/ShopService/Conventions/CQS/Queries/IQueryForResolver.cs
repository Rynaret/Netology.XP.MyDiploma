namespace ShopService.Conventions.CQS.Queries
{
    /// <summary>
    /// Динамическое получение требуемого экземпляра класса IQueryFor
    /// </summary>
    public interface IQueryForResolver
    {
        IQueryFor<T> Resolve<T>();
    }
}