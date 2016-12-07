using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Db.Providers;

namespace Server.Db
{
    /// <summary>
    /// CRUD operation 
    /// </summary>
    /// <typeparam name="T"> T of object for CRUD operation</typeparam>
    public interface ICrud<T>
    {
        /// <summary>
        /// Provider for work with BD
        /// </summary>
        IDbProvider Provider { get; }
        /// <summary>
        /// Create T object
        /// </summary>
        /// <param name="obj">Object</param>
        void Create(T obj);
        /// <summary>
        /// Create or Update. If object exist update also create
        /// </summary>
        /// <param name="obj">Object for operation</param>
        void CreateOrUpdate(T obj);
        /// <summary>
        /// Remove object
        /// </summary>
        /// <param name="obj">Object for operation</param>
        /// <returns>TRUE if remove</returns>
        bool Remove(T obj);
        /// <summary>
        /// Remove object by object id
        /// </summary>
        /// <param name="objectId">Object idintificator</param>
        /// <returns>TRUE if remove</returns>
        bool Remove(object objectId);
        /// <summary>
        /// Create T object ASYNC
        /// </summary>
        /// <param name="obj">Object</param>
        void CreateAsync(T obj);
        /// <summary>
        /// Create or Update ASYNC. If object exist update also create 
        /// </summary>
        /// <param name="obj">Object for operation</param>
        void CreateOrUpdateAsync(T obj);
        /// <summary>
        /// Remove object ASYNC
        /// </summary>
        /// <param name="obj">Object for operation</param>
        /// <returns>TRUE if remove</returns>
        Task<bool> RemoveAsync(T obj);
        /// <summary>
        /// Remove object by object id ASYNC
        /// </summary>
        /// <param name="objectId">Object idintificator</param>
        /// <returns>TRUE if remove</returns>
        Task<bool> RemoveAsync(object objectId);
        /// <summary>
        /// Get all items T object
        /// </summary>
        /// <returns>return all object from DB</returns>
        IList<T> GetAll();
        /// <summary>
        /// Get all items T object ASYNC
        /// </summary>
        /// <returns>return all object from DB</returns>
        Task<List<T>> GetAllAsync();
        /// <summary>
        /// Get filtered items T object
        /// </summary>
        /// <param name="filter">Filter object</param>
        /// <returns>return all object from DB</returns>
        IList<T> GetFiltered(object filter);
        /// <summary>
        /// Get filtered items T object ASYNC
        /// </summary>
        /// <param name="filter">Filter object</param>
        /// <returns>return all object from DB</returns>
        Task<IList<T>> GetFilteredAsync(object filter);
    }
}
