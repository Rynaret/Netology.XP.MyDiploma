using System.Threading.Tasks;
using ShopService.Conventions.CQS.Queries;

namespace ShopService.Conventions.CQS.Extensions
{
    /// <summary>
    /// Расширения для IQueryBuilder
    /// </summary>
    public static class QueryBuilderExtensions
    {
        /// <summary>
        /// Запрос количества элементов, отвечающих запросу
        /// </summary>
        /// <param name="queryBuilder"></param>
        /// <param name="criterion"></param>
        /// <typeparam name="TCriterion"></typeparam>
        /// <returns></returns>
        public static async Task<int> Count<TCriterion>(this IQueryBuilder queryBuilder, TCriterion criterion)
            where TCriterion : class, ICriterion
        {
            return await queryBuilder.For<int>().WithAsync(criterion);
        }
    }
}