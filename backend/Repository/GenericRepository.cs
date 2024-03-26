using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _appDbContext;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            await _appDbContext.Set<TEntity>().AddAsync(entity);
            int result = await _appDbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _appDbContext.Set<TEntity>().FindAsync(id);
            if (entity == null) return false;

            _appDbContext.Set<TEntity>().Remove(entity);
            int result = await _appDbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _appDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _appDbContext.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity> Query()
        {
            return _appDbContext.Set<TEntity>().AsQueryable();
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Update(entity);
            int result = await _appDbContext.SaveChangesAsync();

            return result > 0;
        }
    }
}