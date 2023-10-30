using Housing.Data;

namespace Housing.Repository
{
    public class UnitOfWork<T> : IUnitOfWork where T : class
    {
        public IGenericRepository<Country> Countries => throw new NotImplementedException();

        public IGenericRepository<House> Hotels => throw new NotImplementedException();

        public IGenericRepository<State> States => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}
