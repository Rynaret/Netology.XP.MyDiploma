namespace ShopService.Conventions.CQS.Queries
{
    /// <summary>
    ///     Фабрика объектов запросов
    /// </summary>
    public interface IQueryFactory
    {
        /// <summary>
        ///     Создать запрос, возвращающий необходимые результаты с определенными критериями
        /// </summary>
        /// <typeparam name="TCriterion">критерий запроса, содержащий условия выборки</typeparam>
        /// <typeparam name="TResult">результат, который ожидается получить</typeparam>
        /// <returns> </returns>
        IQuery<TCriterion, TResult> Create<TCriterion, TResult>()
            where TCriterion : ICriterion;
    }
}