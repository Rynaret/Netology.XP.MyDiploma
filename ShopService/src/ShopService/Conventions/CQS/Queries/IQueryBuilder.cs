namespace ShopService.Conventions.CQS.Queries
{
    /// <summary>
    ///     Интерфейс для строителя запросов
    /// </summary>
    public interface IQueryBuilder
    {
        /// <summary>
        ///     Начать строить запрос для результата
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        IQueryFor<TResult> For<TResult>();
    }
}