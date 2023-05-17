using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Server.Db.DataModel;

namespace Server.Db.Repositories.SQLite
{
    public class SqLiteRepository<T> : ISqLiteRepository<T> where T : BaseEntity
    {
        #region [ ISqLiteRepository implementation]

        private readonly DatabaseContext _context;

        private DbSet<T> _entities;

        #region [ .ctor ]

        public SqLiteRepository(string connectionString)
        {
            _context = new DatabaseContext(connectionString);
            _entities = Context.Set<T>();
        }

        #endregion

        /// <summary>
        /// Database context
        /// </summary>
        public DatabaseContext Context => _context;

        /// <summary>
        /// Entities dbset
        /// </summary>
        public DbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());

        /// <summary>
        /// Error message if exist
        /// </summary>
        public string ErrorText { get; set; }

        #region [ ICRUD implementation]

        #region [ Delete ]

        /// <summary>
        /// Delete by id
        /// </summary>
        /// <param name="id">id</param>
        public bool Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException("Id is null or whitespace");

            return Delete(Get(id));
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">entity</param>
        public bool Delete(T entity)
        {
            try
            {
                if (entity == null)
                    return false;

                Context.Remove(entity);
                Context.SaveChanges();
                return true;
            }
            catch (DbException ex)
            {
                ErrorText = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Delete items with filter
        /// </summary>
        /// <param name="filter">expression filter</param>
        public bool Delete(Expression<Func<T, bool>> filter)
        {
            try
            {
                _entities.RemoveRange(Get(filter));
                return true;
            }
            catch (DbException ex)
            {
                ErrorText = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Delete all documents
        /// </summary>
        public bool DeleteAll()
        {
            try
            {
                _entities.RemoveRange(GetAll());
                _context.SaveChanges();
                return true;
            }
            catch (DbException ex)
            {
                ErrorText = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Delete by id
        /// </summary>
        /// <param name="id">id</param>
        public Task<bool> DeleteAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException("Id is null or whitespace");

            return DeleteAsync(Get(id));
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">entity</param>
        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                if (entity == null)
                    return false;

                Context.Remove(entity);
                await Context.SaveChangesAsync();
                return true;
            }
            catch (DbException ex)
            {
                ErrorText = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Delete items with filter
        /// </summary>
        /// <param name="filter">expression filter</param>
        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> filter)
        {
            try
            {
                _entities.RemoveRange(Get(filter));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbException ex)
            {
                ErrorText = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Delete all documents
        /// </summary>
        public async Task<bool> DeleteAllAsync()
        {
            try
            {
                _entities.RemoveRange(GetAll());
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbException ex)
            {
                ErrorText = ex.Message;
                return false;
            }
        }

        #endregion

        #region [ Get ]

        /// <summary>
        /// Get entities
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <returns>collection of entity</returns>
        public T Get(string id)
        {
            return _entities.SingleOrDefault(p => p.Id.ToString() == id);
        }

        /// <summary>
        /// Get entities
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <returns>collection of entity</returns>
        public IEnumerable<T> Get(Expression<Func<T, bool>> filter)
        {
            return _entities.Where(filter);
        }

        /// <summary>
        /// Get entities with paging
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <param name="pageIndex">page index, based on 0</param>
        /// <param name="size">number of items in page</param>
        /// <returns>collection of entity</returns>
        public IEnumerable<T> Get(Expression<Func<T, bool>> filter, int pageIndex, int size)
        {
            return _entities.Where(filter).Skip(pageIndex * size).Take(size);
        }

        /// <summary>
        /// Get entities with paging and ordering
        /// default ordering is descending
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <param name="order">ordering parameters</param>
        /// <param name="pageIndex">page index, based on 0</param>
        /// <param name="size">number of items in page</param>
        /// <returns>collection of entity</returns>
        public IEnumerable<T> Get(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order, int pageIndex, int size)
        {
            return _entities.Where(filter).Skip(pageIndex * size).Take(size).OrderBy(order);
        }

        /// <summary>
        /// Get entities with paging and ordering in direction
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <param name="order">ordering parameters</param>
        /// <param name="pageIndex">page index, based on 0</param>
        /// <param name="size">number of items in page</param>
        /// <param name="isDescending">ordering direction</param>
        /// <returns>collection of entity</returns>
        public IEnumerable<T> Get(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order, int pageIndex, int size, bool isDescending)
        {
            return isDescending
                ? _entities.Where(filter).Skip(pageIndex * size).Take(size).OrderByDescending(order)
                : _entities.Where(filter).Skip(pageIndex * size).Take(size).OrderBy(order);

        }

        #endregion

        #region [ GetAll ]

        /// <summary>
        /// fetch all items in collection
        /// </summary>
        /// <returns>collection of entity</returns>
        public IEnumerable<T> GetAll()
        {
            return _entities.Select(p => p);
        }

        /// <summary>
        /// fetch all items in collection with paging
        /// </summary>
        /// <param name="pageIndex">page index, based on 0</param>
        /// <param name="size">number of items in page</param>
        /// <returns>collection of entity</returns>
        public IEnumerable<T> GetAll(int pageIndex, int size)
        {
            return _entities.Skip(size * pageIndex).Take(size);
        }

        /// <summary>
        /// fetch all items in collection with paging and ordering
        /// default ordering is descending
        /// </summary>
        /// <param name="order">ordering parameters</param>
        /// <param name="pageIndex">page index, based on 0</param>
        /// <param name="size">number of items in page</param>
        /// <returns>collection of entity</returns>
        public IEnumerable<T> GetAll(Expression<Func<T, object>> order, int pageIndex, int size)
        {
            return _entities.Skip(size * pageIndex).Take(size).OrderBy(order);
        }

        /// <summary>
        /// fetch all items in collection with paging and ordering in direction
        /// </summary>
        /// <param name="order">ordering parameters</param>
        /// <param name="pageIndex">page index, based on 0</param>
        /// <param name="size">number of items in page</param>
        /// <param name="isDescending">ordering direction</param>
        /// <returns>collection of entity</returns>
        public IEnumerable<T> GetAll(Expression<Func<T, object>> order, int pageIndex, int size, bool isDescending)
        {
            return isDescending
                ? _entities.Skip(size * pageIndex).Take(size).OrderByDescending(order)
                : _entities.Skip(size * pageIndex).Take(size).OrderBy(order);
        }

        #endregion

        #region [ First ]

        /// <summary>
        /// Get first item in collection
        /// </summary>
        /// <returns>entity of <typeparamref name="T"/></returns>
        public T First()
        {
            return _entities.FirstOrDefault();
        }

        /// <summary>
        /// Get first item in query
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <returns>entity of <typeparamref name="T"/></returns>
        public T First(Expression<Func<T, bool>> filter)
        {
            return _entities.FirstOrDefault(filter);
        }

        /// <summary>
        /// Get first item in query with order
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <param name="order">ordering parameters</param>
        /// <returns>entity of <typeparamref name="T"/></returns>
        public T First(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order)
        {
            return _entities.Where(filter).OrderBy(order).FirstOrDefault();
        }

        /// <summary>
        /// Get first item in query with order and direction
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <param name="order">ordering parameters</param>
        /// <param name="isDescending">ordering direction</param>
        /// <returns>entity of <typeparamref name="T"/></returns>
        public T First(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order, bool isDescending)
        {
            return (isDescending ? _entities.Where(filter).OrderByDescending(order) : _entities.Where(filter).OrderBy(order)).FirstOrDefault();
        }

        #endregion

        #region [ Insert ]

        /// <summary>
        /// insert entity
        /// </summary>
        /// <param name="entity">entity</param>
        public void Insert(T entity)
        {
            _entities.Add(entity);
        }

        /// <summary>
        /// insert entity
        /// </summary>
        /// <param name="entity">entity</param>
        public Task InsertAsync(T entity)
        {
            return _entities.AddAsync(entity);
        }

        /// <summary>
        /// insert entity collection
        /// </summary>
        /// <param name="entities">collection of entities</param>
        public void Insert(IEnumerable<T> entities)
        {
            _entities.AddRange(entities);
        }

        /// <summary>
        /// insert entity collection
        /// </summary>
        /// <param name="entities">collection of entities</param>
        public Task InsertAsync(IEnumerable<T> entities)
        {
            return _entities.AddRangeAsync(entities);
        }

        #endregion

        #region [ Last ]

        /// <summary>
        /// Get last item in collection
        /// </summary>
        /// <returns>entity of <typeparamref name="T"/></returns>
        public T Last()
        {
            return _entities.LastOrDefault();
        }

        /// <summary>
        /// Get last item in query
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <returns>entity of <typeparamref name="T"/></returns>
        public T Last(Expression<Func<T, bool>> filter)
        {
            return _entities.LastOrDefault(filter);
        }

        /// <summary>
        /// Get last item in query with order
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <param name="order">ordering parameters</param>
        /// <returns>entity of <typeparamref name="T"/></returns>
        public T Last(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order)
        {
            return _entities.Where(filter).OrderBy(order).LastOrDefault();
        }

        /// <summary>
        /// Get last item in query with order and direction
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <param name="order">ordering parameters</param>
        /// <param name="isDescending">ordering direction</param>
        /// <returns>entity of <typeparamref name="T"/></returns>
        public T Last(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order, bool isDescending)
        {
            return (isDescending ? _entities.Where(filter).OrderByDescending(order) : _entities.Where(filter).OrderBy(order)).LastOrDefault();
        }

        #endregion

        #region [ Replace ]

        /// <summary>
        /// replace an existing entity
        /// </summary>
        /// <param name="entity">entity</param>
        public bool Replace(T entity)
        {
            _entities.Add(entity);
            return Delete(entity);
        }

        /// <summary>
        /// replace an existing entity
        /// </summary>
        /// <param name="entity">entity</param>
        public Task<bool> ReplaceAsync(T entity)
        {
            _entities.Add(entity);
            return DeleteAsync(entity);
        }

        /// <summary>
        /// replace collection of entities
        /// </summary>
        /// <param name="entities">collection of entities</param>
        public void Replace(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _entities.Remove(entity);
                _entities.Add(entity);
            }
            _context.SaveChanges();
        }

        #endregion

        #region [ Update ]

        /// <summary>
        /// update an entity with updated fields
        /// </summary>
        /// <param name="entity">entity</param>
        public bool Update(T entity)
        {
            try
            {
                _entities.Update(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ErrorText = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// update an entity with updated fields
        /// </summary>
        /// <param name="entity">entity</param>
        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _entities.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                ErrorText = ex.Message;
                return false;
            }
        }

        #endregion

        #region Utils

        /// <summary>
        /// validate if filter result exists
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <returns>true if exists, otherwise false</returns>
        public bool Any(Expression<Func<T, bool>> filter)
        {
            return _entities.Any(filter);
        }

        #endregion

        #region [ Count ]

        /// <summary>
        /// get number of filtered documents
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <returns>number of documents</returns>
        public long Count(Expression<Func<T, bool>> filter)
        {
            return _entities.Count(filter);
        }

        /// <summary>
        /// get number of filtered documents
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <returns>number of documents</returns>
        public async Task<long> CountAsync(Expression<Func<T, bool>> filter)
        {
            return await _entities.CountAsync(filter);
        }

        /// <summary>
        /// get number of documents in collection
        /// </summary>
        /// <returns>number of documents</returns>
        public long Count()
        {
            return _entities.Count();
        }

        /// <summary>
        /// get number of documents in collection
        /// </summary>
        /// <returns>number of documents</returns>
        public async Task<long> CountAsync()
        {
            return await _entities.CountAsync();
        }

        #endregion

        #endregion

        #endregion
    }
}
