using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Db.Providers
{
    public class MsSqlProvider : IMsSqlProvider
    {
        public void Create<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdate<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public bool Remove<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public bool Remove(object objectId)
        {
            throw new NotImplementedException();
        }

        public void CreateAsync<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdateAsync<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public void RemoveAsync<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public void RemoveAsync(object objectId)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll<T>()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync<T>()
        {
            throw new NotImplementedException();
        }

        public IList<T> GetFiltered<T>(object filter)
        {
            throw new NotImplementedException();
        }

        public Task<IList<T>> GetFilteredAsync<T>(object filter)
        {
            throw new NotImplementedException();
        }
    }
}
