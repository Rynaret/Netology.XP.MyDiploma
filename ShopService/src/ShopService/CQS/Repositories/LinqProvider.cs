using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopService.Conventions;
using ShopService.Conventions.Repositories;

namespace ShopService.CQS.Repositories
{
    public sealed class LinqProvider : ILinqProvider
    {
        private readonly DbContext _context;

        public LinqProvider(DbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> Query<TEntity>()
            where TEntity : class, IEntity, new()
        {
            var dbset = _context.Set<TEntity>();

            return dbset.AsNoTracking().AsQueryable();
        }
    }
}