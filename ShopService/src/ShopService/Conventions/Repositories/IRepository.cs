using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopService.Conventions.Repositories
{
    /// <summary>
    /// Дженерик репозиторий для работы с ORM
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class, IEntity
    {
        /// <summary>
        /// Используется для получения сущностей с последующим изменением
        /// </summary>
        IQueryable<T> Query { get; } 
        /// <summary>
        /// Используется только для чтения
        /// </summary>
        IQueryable<T> ReadQuery { get; }
        T Get(object id);
        /// <summary>
        /// Добавление сущности
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Add(T entity);
        /// <summary>
        /// Удаление сущности
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
        /// <summary>
        /// Сохранение изменений сущности
        /// </summary>
        /// <param name="entity"></param>
        void Edit(T entity);
        /// <summary>
        /// Сохранение изменений списка сущностей 
        /// </summary>
        /// <param name="entities"></param>
        void Edit(IList<T> entities);
        /// <summary>
        /// Добавление списка сущностей
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        IList<T> AddRange(IList<T> entities);
        /// <summary>
        /// Удаление списка сущностей
        /// </summary>
        /// <param name="entities"></param>
        void DeleteRange(IList<T> entities);
        /// <summary>
        /// Получение всех записей в таблице
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Синхронное сохранение изменений в БД
        /// </summary>
        void Save();
        /// <summary>
        /// Асинхронное сохранение изменений в БД
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();
    }
}