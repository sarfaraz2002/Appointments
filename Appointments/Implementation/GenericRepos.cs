using Appointments.DataContext;
using Appointments.Repository;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Implementation
{
    public class GenericRepos<T> : IGenericRepos<T> where T : class
    {
        private readonly DbDataContext _dbConnection;
        public GenericRepos(DbDataContext dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public void Add(T entity)
        {
            _dbConnection.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbConnection.Set<T>().AddRange(entities);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbConnection.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbConnection.Set<T>().FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dbConnection.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbConnection.Set<T>().RemoveRange(entities);
        }
    }
}
