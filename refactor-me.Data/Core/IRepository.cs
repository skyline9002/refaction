using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RefactionMe.Data.Core
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Add entity as new.
        /// </summary>
        /// <param name="entity">entity model</param>
        void Add(T entity);

        /// <summary>
        /// Mark entity as updated
        /// </summary>
        /// <param name="entity">entity model</param>
        void Update(T entity);

        /// <summary>
        /// Mark entity as deleted.
        /// </summary>
        /// <param name="entity">entity model</param>
        void Delete(T entity);

        /// <summary>
        /// Mark entity as deleted by lamda expression.
        /// </summary>
        /// <param name="where">lamda expression</param>
        void Delete(Expression<Func<T, bool>> where);

        /// <summary>
        /// Get single entity by Guid Id.  
        /// </summary>
        /// <param name="id">Guid, Id</param>
        /// <returns>entity model</returns>
        T GetById(Guid id);

        /// <summary>
        /// Get single entity by lamda expression.
        /// </summary>
        /// <param name="where">lamda expression</param>
        /// <returns>entity model</returns>
        T Get(Expression<Func<T, bool>> where);

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>A list of entities</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Get multiple entities by lamda expression.
        /// </summary>
        /// <param name="where">lamda expression.</param>
        /// <returns>A list of entities</returns>
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    }
}
