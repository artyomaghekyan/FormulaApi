using FormulaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace FormulaApi.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DriverDbContext _context;
        internal DbSet<T> _dbSet;
        private readonly ILogger _logger;
        public GenericRepository(DriverDbContext context,DbSet<T> dbSet, ILogger logger)
        {
            _context = context;
            this._dbSet = _context.Set<T>();
            _logger = logger;

        }
        public virtual async Task<bool> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return true;
        }
    }
}
