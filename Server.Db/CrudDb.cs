using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Db
{
    public class CrudDb<T, TProvider> : ICrud<T> where T : new()
    {
        public void Create(T obj)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdate(T obj)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T obj)
        {
            throw new NotImplementedException();
        }

        public bool Remove(object objectId)
        {
            throw new NotImplementedException();
        }

        public void CreateAsync(T obj)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdateAsync(T obj)
        {
            throw new NotImplementedException();
        }

        public bool RemoveAsync(T obj)
        {
            throw new NotImplementedException();
        }

        public bool RemoveAsync(object objectId)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IList<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IList<T> GetFiltered(object filter)
        {
            throw new NotImplementedException();
        }

        public Task<IList<T>> GetFilteredAsync(object filter)
        {
            throw new NotImplementedException();
        }
    }
}
