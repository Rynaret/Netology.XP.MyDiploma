using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopService.Conventions;
using ShopService.Conventions.Repositories;

namespace ShopService.CQS.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext _entities;
        private readonly DbSet<T> _dbset;

        public EfRepository(DbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public IQueryable<T> Query => _dbset.AsQueryable();
        public IQueryable<T> ReadQuery => _dbset.AsNoTracking();

        public T Get(object id)
        {
            var entity = _dbset.FirstOrDefault(x => x.Id == (long)id);
            return entity;
        }
        
        public T Add(T entity)
        {
            return _dbset.Add(entity).Entity;
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }
        
        public void Edit(T entity)
        {
            // пока ничего не выполняется
        }

        public void Edit(IList<T> entities)
        {
            // пока ничего не выполняется
        }

        public IList<T> AddRange(IList<T> entities)
        {
            _dbset.AddRange(entities);
            return entities;
        }
        
        public void DeleteRange(IList<T> entities)
        {
            _dbset.RemoveRange(entities);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable();
        }

        public void Save()
        {
            _entities.SaveChanges();
        }

        public Task SaveAsync()
        {
            return _entities.SaveChangesAsync();
        }
    }
}