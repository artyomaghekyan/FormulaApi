namespace FormulaApi.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IDriverRepository Drivers { get; }
        Task CompleteAsync();

    }
}
