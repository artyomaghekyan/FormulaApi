using FormulaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FormulaApi.Data
{
    public class DriverDbContext : DbContext
    {
        public DriverDbContext(DbContextOptions<DriverDbContext> options) : base(options)
        {
            
        }
        public DbSet<Driver> Drivers { get; set; }
    }
}
