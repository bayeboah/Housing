using Housing.Data;

namespace Housing.Repository
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly DatabaseContext _databaseContext;

        // backtracking
        private IGenericRepository<Country> _countries;
        private IGenericRepository<House> _houses;
        private IGenericRepository<State> _states;

        public UnitOfWork(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public IGenericRepository<Country> Countries => _countries ??= new GenericRepository<Country>(_databaseContext);

        public IGenericRepository<House> Houses => _houses ??= new GenericRepository<House>(_databaseContext) ;

        public IGenericRepository<State> States => _states ??= new GenericRepository<State>(_databaseContext);

        public void Dispose()
        {
            _databaseContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _databaseContext.SaveChangesAsync();
        }
    }
}
