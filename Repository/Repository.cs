using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DBContext _dbContext;
        public Repository(DBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public T Create(T entity)
        {
            return _dbContext.Set<T>().Add(entity).Entity;
        }

        public bool Delete(T entity)
        {
            return _dbContext.Set<T>().Remove(entity) != null;

        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().Where(e => e.IsDeleted == false);
        }

        public T GetByID(int id)
        {
            return _dbContext.Set<T>().Where(e => e.ID == id && e.IsDeleted == false).FirstOrDefault();
        }

        public T Update(T entity)
        {
            return _dbContext.Set<T>().Update(entity).Entity;
        }
    }
}
