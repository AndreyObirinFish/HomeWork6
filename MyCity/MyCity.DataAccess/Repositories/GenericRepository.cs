using Microsoft.EntityFrameworkCore;
using MyCity.Core.Abstractions.Repositories;
using MyCity.Core.Domain;

namespace MyCity.DataAccess.Repositories
{
    internal class GenericRepository<TEntity, TDbContext> : IRepository<TEntity>
        where TEntity : BaseEntity where TDbContext : DbContext
    {
        private readonly TDbContext _context;

        public GenericRepository(TDbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().Where(x => x.IsActive).AsQueryable();
        }

        public IQueryable<TEntity> GetById(Guid id)
        {
            return _context.Set<TEntity>().Where(x => x.Id == id).AsQueryable();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public async Task SaveEntitiesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

