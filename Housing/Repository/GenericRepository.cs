﻿using System.Linq.Expressions;

namespace Housing.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public Task InsertRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
