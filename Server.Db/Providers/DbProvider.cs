using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Db.Providers
{
    public class DbProvider : IDbProvider
    {
        public void Create<T>(T obj)
        {
            throw new System.NotImplementedException();
        }

        public void CreateOrUpdate<T>(T obj) where T : IMongoDataModel
        {
            throw new System.NotImplementedException();
        }

        public bool Remove<T>(T obj) where T : IMongoDataModel
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(object objectId)
        {
            throw new System.NotImplementedException();
        }

        public void CreateAsync<T>(T obj)
        {
            throw new System.NotImplementedException();
        }

        public void CreateOrUpdateAsync<T>(T obj) where T : IMongoDataModel
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAsync<T>(T obj) where T : IMongoDataModel
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAsync(object objectId)
        {
            throw new System.NotImplementedException();
        }

        public IList<T> GetAll<T>()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<T>> GetAllAsync<T>()
        {
            throw new System.NotImplementedException();
        }

        public IList<T> GetFiltered<T>(object filter)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<T>> GetFilteredAsync<T>(object filter)
        {
            throw new System.NotImplementedException();
        }
    }
}