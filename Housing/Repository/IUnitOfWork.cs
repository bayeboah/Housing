using Housing.Data;

namespace Housing.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Country> Countries { get; }

        IGenericRepository<House> Hotels { get; }

        IGenericRepository<State> States { get; }

        Task Save();

    }
}
