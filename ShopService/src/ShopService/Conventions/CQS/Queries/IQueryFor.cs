using System.Threading.Tasks;

namespace ShopService.Conventions.CQS.Queries
{
    /// <summary>
    ///     Интерфейс для задания критериев запроса
    /// </summary>
    /// <typeparam name="T">Тип возращаемого запросом значения</typeparam>
    public interface IQueryFor<T>
    {
        /// <summary>
        ///     Добавить критерии запроса
        /// </summary>
        /// <param name="criterion"></param>
        /// <typeparam name="TCriterion"></typeparam>
        /// <returns></returns>
        Task<T> WithAsync<TCriterion>(TCriterion criterion)
            where TCriterion : ICriterion;
    }
}