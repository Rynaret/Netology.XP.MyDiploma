using System.Threading.Tasks;

namespace ShopService.Conventions.CQS.Queries
{
    /// <summary>
    ///     Интерфейс для объектов запросов к базе
    /// </summary>
    /// <typeparam name="TCriterion">критерий запроса, содержащий условия выборки</typeparam>
    /// <typeparam name="TResult">результат, который ожидается получить</typeparam>
    public interface IQuery<in TCriterion, TResult>
        where TCriterion : ICriterion
    {
        /// <summary>
        ///     Получить результат из базы
        /// </summary>
        /// <param name="criterion">критерий запроса, содержащий условия выборки</param>
        /// <returns> </returns>
        Task<TResult> AskAsync(TCriterion criterion);
    }
}