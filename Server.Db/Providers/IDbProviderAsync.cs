using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Db.Providers
{
    /// <summary>
    /// DataBase provider. Interface for work with DB
    /// </summary>
    public interface IDbProviderAsync
    {
        /// <summary>
        /// Create T object ASYNC
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="obj">Object for creation</param>
        void CreateAsync<T>(T obj);
        /// <summary>
        /// Create or Update ASYNC. If object exist update also create 
        /// </summary>
        /// <param name="obj">Object for operation</param>
        void CreateOrUpdateAsync<T>(T obj);
        /// <summary>
        /// Remove object by object id ASYNC
        /// </summary>
        /// <param name="objectId">Object idintificator</param>
        Task<bool> RemoveAsync(object objectId);
        /// <summary>
        /// Get all items T object ASYNC
        /// </summary>
        /// <returns>return all object from DB</returns>
        Task<List<T>> GetAllAsync<T>();
        /// <summary>
        /// Get filtered items T object ASYNC
        /// </summary>
        /// <param name="filter">Filter object</param>
        /// <returns>return all object from DB</returns>
        Task<List<T>> GetFilteredAsync<T>(object filter);
        /// <summary>
        /// Get item T object by id ASYNC
        /// </summary>
        /// <param name="id">Idintifier of object</param>
        /// <returns>return T object</returns>
        Task<T> GetByIdAsync<T>(object id);
    }
}
