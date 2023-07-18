using CarRentalSystem.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Infraestructure.Data.Implementation
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly CarRentalDbContext _dbContext;

        public BaseRepository(CarRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            var value = GetKeyByEntity(entity);
            T original = _dbContext.Set<T>().Find(value);
            _dbContext.Entry(original).CurrentValues.SetValues(entity);
            this._dbContext.SaveChanges();

        }

        private object GetKeyByEntity(T entity)
        {
            var keyName = _dbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey()?.Properties?.FirstOrDefault()?.Name;
            return entity.GetType().GetProperty(keyName).GetValue(entity, null);
        }
    }
}
