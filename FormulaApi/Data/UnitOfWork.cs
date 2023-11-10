using FormulaApi.Core;

namespace FormulaApi.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IDriverRepository Drivers { get; private set; }
        private readonly DriverDbContext _context;
        private readonly ILogger _logger;

        public UnitOfWork(DriverDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;

            //Drivers = new IDriverRepository(context, logger);
        }
        public Task CompleteAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
