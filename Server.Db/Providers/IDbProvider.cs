using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Db.Providers
{
    /// <summary>
    /// DataBase provider. Interface for work with DB
    /// </summary>
    public interface IDbProvider
    {
        /// <summary>
        /// Create T object
        /// </summary>
        /// <param name="obj">Object</param>
        void Create<T>(T obj);
        /// <summary>
        /// Create or Update. If object exist update also create
        /// </summary>
        /// <param name="obj">Object for operation</param>
        void CreateOrUpdate<T>(T obj);
        /// <summary>
        /// Remove object
        /// </summary>
        /// <param name="obj">Object for operation</param>
        /// <returns>TRUE if remove</returns>
        bool Remove<T>(T obj);
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
        void CreateAsync<T>(T obj);
        /// <summary>
        /// Create or Update ASYNC. If object exist update also create 
        /// </summary>
        /// <param name="obj">Object for operation</param>
        void CreateOrUpdateAsync<T>(T obj);
        /// <summary>
        /// Remove object ASYNC
        /// </summary>
        /// <param name="obj">Object for operation</param>
        void RemoveAsync<T>(T obj);
        /// <summary>
        /// Remove object by object id ASYNC
        /// </summary>
        /// <param name="objectId">Object idintificator</param>
        void RemoveAsync(object objectId);
        /// <summary>
        /// Get all items T object
        /// </summary>
        /// <returns>return all object from DB</returns>
        IList<T> GetAll<T>();
        /// <summary>
        /// Get all items T object ASYNC
        /// </summary>
        /// <returns>return all object from DB</returns>
        Task<List<T>> GetAllAsync<T>();
        /// <summary>
        /// Get filtered items T object
        /// </summary>
        /// <param name="filter">Filter object</param>
        /// <returns>return all object from DB</returns>
        IList<T> GetFiltered<T>(object filter);
        /// <summary>
        /// Get filtered items T object ASYNC
        /// </summary>
        /// <param name="filter">Filter object</param>
        /// <returns>return all object from DB</returns>
        Task<IList<T>> GetFilteredAsync<T>(object filter);
    }
}
