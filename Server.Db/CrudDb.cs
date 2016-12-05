using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Db.Providers;

namespace Server.Db
{
    public class CrudDb<T, TProvider> : ICrud<T> where T : new() where TProvider : IMongoDbProvider
    {
        private TProvider _provider { get; set; }

        public CrudDb(EDataBase dataBase, string connectionString)
        {
            switch (dataBase)
            {
                case EDataBase.MogoDataBase:
                    _provider = new MongoDBProvider<T>(connectionString);
                    break;
                case EDataBase.MsSql:
                    _provider = new MsSqlProvider();
                    break;
                case EDataBase.PostgresSql:
                    _provider = new PosgresSqlProvider();
                    break;
                default:
                    throw new ArgumentException("EDataBase type not supported");
            }
        }

        public void Create(T obj)
        {
            _provider.Create(obj);
        }

        public void CreateOrUpdate(T obj)
        {
            _provider.CreateOrUpdate(obj);
        }

        public bool Remove(T obj)
        {
            return _provider.Remove(obj);
        }

        public bool Remove(object objectId)
        {
            return _provider.Remove(objectId);
        }

        public void CreateAsync(T obj)
        {
            _provider.CreateAsync(obj);
        }

        public void CreateOrUpdateAsync(T obj)
        {
            _provider.CreateOrUpdateAsync(obj);
        }

        public async Task<bool> RemoveAsync(T obj)
        {
            _provider.RemoveAsync(obj);
            return true;
        }

        public async Task<bool> RemoveAsync(object objectId)
        {
            _provider.RemoveAsync(objectId);
            return true;
        }

        public IList<T> GetAll()
        {
            return _provider.GetAll<T>();
        }

        public Task<List<T>> GetAllAsync()
        {
            return _provider.GetAllAsync<T>();
        }

        public IList<T> GetFiltered(object filter)
        {
            return _provider.GetFiltered<T>(filter);
        }

        public Task<IList<T>> GetFilteredAsync(object filter)
        {
            return _provider.GetFilteredAsync<T>(filter);
        }
    }
}
