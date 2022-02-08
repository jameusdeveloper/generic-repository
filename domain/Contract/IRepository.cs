using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Domain.Entities;

namespace Domain.Contract
{
    public interface IRepository<T> where T : EntityBase
    {
        /// <summary>
        /// Returns all elements with AsNoTracking
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Returns one entity match the condition with AsNoTracking Reference
        /// </summary>
        /// <param name="predicate">linq expression to filter the result</param>
        /// <param name="navigationProperties">the name of the related entities</param>
        /// <returns></returns>
        T GetOne(Expression<Func<T, bool>> predicate, params string[] navigationProperties);

        /// <summary>
        /// Update entity in database
        /// </summary>
        /// <param name="entity">Entity to be updated</param>
        /// <returns></returns>
        public bool Update(T entity);

        /// <summary>
        /// Add entity in database
        /// </summary>
        /// <param name="entity">Entity to be added</param>
        /// <returns></returns>
        public bool Create(T entity);

        /// <summary>
        /// Remove entity in database
        /// </summary>
        /// <param name="entity">Entity to be removed</param>
        /// <returns></returns>
        public bool Delete(T entity);

        /// <summary>
        /// Returns all elements match the condition with AsNoTracking Reference
        /// </summary>
        /// <param name="predicate">linq expression to filter the result</param>
        /// <param name="navigationProperties">the name of the related entities</param>
        /// <returns></returns>
        IEnumerable<T> GetByExpression(Expression<Func<T, bool>> predicate, params string[] navigationProperties);

        /// <summary>
        /// Count the amount of records result for a given lambda expression
        /// </summary>
        /// <param name="predicate">filter results by a given expression</param>
        /// <returns></returns>
        public Task<int> CountByExpression(Expression<Func<T, bool>> predicate);
    }
}