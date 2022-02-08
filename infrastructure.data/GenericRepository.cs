using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Domain.Contract;
using Domain.Entities;
using System.Collections.Generic;

namespace Infrastructure
{
    public class GenericRepository<T> : IRepository<T> where T : EntityBase
    {
        private readonly GenericDbContext _dbContext;

        public GenericRepository(GenericDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking().AsQueryable();
        }

        public T GetOne(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
        {
            IQueryable<T> query = _dbContext.Set<T>().AsNoTracking().Where(predicate);

            foreach (string navigationProperty in navigationProperties ?? Array.Empty<string>())
            {
                query = query.Include(navigationProperty);
            }

            return query.FirstOrDefault();
        }

        public bool Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public IEnumerable<T> GetByExpression(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
        {
            IQueryable<T> query = _dbContext.Set<T>().AsNoTracking().Where(predicate);

            foreach (string navigationProperty in navigationProperties ?? Array.Empty<string>())
            {
                query = query.Include(navigationProperty);
            }

            return query;
        }

        public Task<int> CountByExpression(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().CountAsync(predicate);
        }
    }
}