using FormulaApi.Data;
using FormulaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FormulaApi.Core.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(DriverDbContext context, DbSet<Driver> dbSet, ILogger logger) : base(context, dbSet, logger)
        {
        }

        public override async Task<IEnumerable<Driver>> GetAllAsync()
        {
            return await _context.Drivers.Where(x => x.Id < 100).ToListAsync();
        }

        public async Task<Driver> GetByDriverNum(string num)
        {
            try
            {
               
                return await _context.Drivers.FirstOrDefaultAsync(x => x.DriverNumber == num);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
