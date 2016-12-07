using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Db.Providers;

namespace Server.Db
{
    public class CrudDb<T, TProvider> : ICrud<T> where T : IMongoDataModel<T> where TProvider : class
    {
        #region [ private field ]

        private TProvider _provider { get; set; }

        private readonly EDataBase _dataBaseType;

        #endregion

        #region [ .ctor ]

        public CrudDb(EDataBase dataBase, string connectionString)
        {
            _dataBaseType = dataBase;
            switch (dataBase)
            {
                case EDataBase.MogoDataBase:
                    _provider = new MongoDBProvider<T>(connectionString) as TProvider;
                    break;
                case EDataBase.MsSql:
                    _provider = new MsSqlProvider() as TProvider;
                    break;
                case EDataBase.PostgresSql:
                    _provider = new PosgresSqlProvider() as TProvider;
                    break;
                default:
                    throw new ArgumentException("EDataBase type not supported");
            }
        }

        #endregion

        #region [ ICrud implementation ]

        public IDbProvider Provider
        {
            get
            {
                switch (_dataBaseType)
                {
                    case EDataBase.MogoDataBase:
                        return _provider as IMongoDbProvider;
                    case EDataBase.MsSql:
                        return _provider as IMsSqlProvider;
                    case EDataBase.PostgresSql:
                        return _provider as IPosgresSqlProvider;
                    default:
                        return null;
                }
            }
        }

        public void Create(T obj)
        {
            Provider.Create(obj);
        }

        public void CreateOrUpdate(T obj)
        {
            Provider.CreateOrUpdate(obj);
        }

        public bool Remove(T obj)
        {
            return Provider.Remove(obj);
        }

        public bool Remove(object objectId)
        {
            return Provider.Remove(objectId);
        }

        public void CreateAsync(T obj)
        {
            Provider.CreateAsync(obj);
        }

        public void CreateOrUpdateAsync(T obj)
        {
            Provider.CreateOrUpdateAsync(obj);
        }

        public async Task<bool> RemoveAsync(T obj)
        {
            Provider.RemoveAsync(obj);
            return true;
        }

        public async Task<bool> RemoveAsync(object objectId)
        {
            Provider.RemoveAsync(objectId);
            return true;
        }

        public IList<T> GetAll()
        {
            return Provider.GetAll<T>();
        }

        public Task<List<T>> GetAllAsync()
        {
            return Provider.GetAllAsync<T>();
        }

        public IList<T> GetFiltered(object filter)
        {
            return Provider.GetFiltered<T>(filter);
        }

        public Task<IList<T>> GetFilteredAsync(object filter)
        {
            return Provider.GetFilteredAsync<T>(filter);
        }

        #endregion
    }
}
