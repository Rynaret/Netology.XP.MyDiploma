using System.Linq;

namespace ShopService.Conventions.Repositories
{
    /// <summary>
    /// Провайдер возвращающий IQueryable интерфейс для чтения данных из БД
    /// </summary>
    public interface ILinqProvider
    {
        /// <summary>
        /// Объект запроса для конкретной сущности
        /// </summary>
        IQueryable<TEntity> Query<TEntity>()
            where TEntity : class, IEntity, new();
    }
}