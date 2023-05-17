using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Server.Db.Repositories
{
    /// <summary>
    /// CRUD operation 
    /// </summary>
    /// <typeparam name="T"> T of object for CRUD operation</typeparam>
    public interface ICrud<T>
    {
        #region CRUD

        #region Delete

        /// <summary>
        /// delete by id
        /// </summary>
        /// <param name="id">id</param>
        bool Delete(string id);


        /// <summary>
        /// delete entity
        /// </summary>
        /// <param name="entity">entity</param>
        bool Delete(T entity);

        /// <summary>
        /// delete items with filter
        /// </summary>
        /// <param name="filter">expression filter</param>
        bool Delete(Expression<Func<T, bool>> filter);

        /// <summary>
        /// delete all documents
        /// </summary>
        bool DeleteAll();

        /// <summary>
        /// delete by id
        /// </summary>
        /// <param name="id">id</param>
        Task<bool> DeleteAsync(string id);

        /// <summary>
        /// delete entity
        /// </summary>
        /// <param name="entity">entity</param>
        Task<bool> DeleteAsync(T entity);

        /// <summary>
        /// delete items with filter
        /// </summary>
        /// <param name="filter">expression filter</param>
        Task<bool> DeleteAsync(Expression<Func<T, bool>> filter);

        /// <summary>
        /// delete all documents
        /// </summary>
        Task<bool> DeleteAllAsync();
        #endregion Delete

        #region Get

        /// <summary>
        /// Get entities
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <returns>collection of entity</returns>
        IEnumerable<T> Get(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Get entities with paging
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <param name="pageIndex">page index, based on 0</param>
        /// <param name="size">number of items in page</param>
        /// <returns>collection of entity</returns>
        IEnumerable<T> Get(Expression<Func<T, bool>> filter, int pageIndex, int size);

        /// <summary>
        /// Get entities with paging and ordering
        /// default ordering is descending
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <param name="order">ordering parameters</param>
        /// <param name="pageIndex">page index, based on 0</param>
        /// <param name="size">number of items in page</param>
        /// <returns>collection of entity</returns>
        IEnumerable<T> Get(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order, int pageIndex, int size);

        /// <summary>
        /// Get entities with paging and ordering in direction
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <param name="order">ordering parameters</param>
        /// <param name="pageIndex">page index, based on 0</param>
        /// <param name="size">number of items in page</param>
        /// <param name="isDescending">ordering direction</param>
        /// <returns>collection of entity</returns>
        IEnumerable<T> Get(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order, int pageIndex, int size, bool isDescending);

        #endregion Get

        #region GetAll

        /// <summary>
        /// fetch all items in collection
        /// </summary>
        /// <returns>collection of entity</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// fetch all items in collection with paging
        /// </summary>
        /// <param name="pageIndex">page index, based on 0</param>
        /// <param name="size">number of items in page</param>
        /// <returns>collection of entity</returns>
        IEnumerable<T> GetAll(int pageIndex, int size);

        /// <summary>
        /// fetch all items in collection with paging and ordering
        /// default ordering is descending
        /// </summary>
        /// <param name="order">ordering parameters</param>
        /// <param name="pageIndex">page index, based on 0</param>
        /// <param name="size">number of items in page</param>
        /// <returns>collection of entity</returns>
        IEnumerable<T> GetAll(Expression<Func<T, object>> order, int pageIndex, int size);

        /// <summary>
        /// fetch all items in collection with paging and ordering in direction
        /// </summary>
        /// <param name="order">ordering parameters</param>
        /// <param name="pageIndex">page index, based on 0</param>
        /// <param name="size">number of items in page</param>
        /// <param name="isDescending">ordering direction</param>
        /// <returns>collection of entity</returns>
        IEnumerable<T> GetAll(Expression<Func<T, object>> order, int pageIndex, int size, bool isDescending);

        #endregion GetAll

        #region First

        /// <summary>
        /// get first item in collection
        /// </summary>
        /// <returns>entity of <typeparamref name="T"/></returns>
        T First();

        /// <summary>
        /// get first item in query
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <returns>entity of <typeparamref name="T"/></returns>
        T First(Expression<Func<T, bool>> filter);

        /// <summary>
        /// get first item in query with order
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <param name="order">ordering parameters</param>
        /// <returns>entity of <typeparamref name="T"/></returns>
        T First(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order);

        /// <summary>
        /// get first item in query with order and direction
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <param name="order">ordering parameters</param>
        /// <param name="isDescending">ordering direction</param>
        /// <returns>entity of <typeparamref name="T"/></returns>
        T First(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order, bool isDescending);

        #endregion First

        #region Get

        /// <summary>
        /// get by id
        /// </summary>
        /// <param name="id">id value</param>
        /// <returns>entity of <typeparamref name="T"/></returns>
        T Get(string id);

        #endregion Get

        #region Insert

        /// <summary>
        /// insert entity
        /// </summary>
        /// <param name="entity">entity</param>
        void Insert(T entity);

        /// <summary>
        /// insert entity
        /// </summary>
        /// <param name="entity">entity</param>
        Task InsertAsync(T entity);

        /// <summary>
        /// insert entity collection
        /// </summary>
        /// <param name="entities">collection of entities</param>
        void Insert(IEnumerable<T> entities);

        /// <summary>
        /// insert entity collection
        /// </summary>
        /// <param name="entities">collection of entities</param>
        Task InsertAsync(IEnumerable<T> entities);

        #endregion Insert

        #region Last

        /// <summary>
        /// get last item in collection
        /// </summary>
        /// <returns>entity of <typeparamref name="T"/></returns>
        T Last();

        /// <summary>
        /// get last item in query
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <returns>entity of <typeparamref name="T"/></returns>
        T Last(Expression<Func<T, bool>> filter);

        /// <summary>
        /// get last item in query with order
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <param name="order">ordering parameters</param>
        /// <returns>entity of <typeparamref name="T"/></returns>
        T Last(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order);

        /// <summary>
        /// get last item in query with order and direction
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <param name="order">ordering parameters</param>
        /// <param name="isDescending">ordering direction</param>
        /// <returns>entity of <typeparamref name="T"/></returns>
        T Last(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order, bool isDescending);

        #endregion Last

        #region Replace

        /// <summary>
        /// replace an existing entity
        /// </summary>
        /// <param name="entity">entity</param>
        bool Replace(T entity);

        /// <summary>
        /// replace an existing entity
        /// </summary>
        /// <param name="entity">entity</param>
        Task<bool> ReplaceAsync(T entity);

        /// <summary>
        /// replace collection of entities
        /// </summary>
        /// <param name="entities">collection of entities</param>
        void Replace(IEnumerable<T> entities);

        #endregion Replace

        #endregion CRUD

        #region Utils
        /// <summary>
        /// validate if filter result exists
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <returns>true if exists, otherwise false</returns>
        bool Any(Expression<Func<T, bool>> filter);

        #region Count
        /// <summary>
        /// get number of filtered documents
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <returns>number of documents</returns>
        long Count(Expression<Func<T, bool>> filter);

        /// <summary>
        /// get number of filtered documents
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <returns>number of documents</returns>
        Task<long> CountAsync(Expression<Func<T, bool>> filter);

        /// <summary>
        /// get number of documents in collection
        /// </summary>
        /// <returns>number of documents</returns>
        long Count();

        /// <summary>
        /// get number of documents in collection
        /// </summary>
        /// <returns>number of documents</returns>
        Task<long> CountAsync();
        #endregion Count

        #endregion Utils
    }
}
