using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Db.Providers;

namespace Server.Db
{
    public class CrudDb<T> : ICrud<T>
    {
        #region [ private field ]

        private readonly EDataBase _dataBaseType;

        private readonly object _provider;

        #endregion

        #region [ .ctor ]

        public CrudDb(EDataBase dataBase, string connectionString)
        {
            _dataBaseType = dataBase;
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

        public IDbProviderAsync ProviderAsync
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

        public bool Remove(object objectId)
        {
            return Provider.Remove(objectId);
        }

        public void CreateAsync(T obj)
        {
            ProviderAsync.CreateAsync(obj);
        }

        public void CreateOrUpdateAsync(T obj)
        {
            ProviderAsync.CreateOrUpdateAsync(obj);
        }
        public Task<bool> RemoveAsync(object objectId)
        {
            return ProviderAsync.RemoveAsync(objectId);
        }

        public IList<T> GetAll()
        {
            return Provider.GetAll<T>();
        }

        public Task<List<T>> GetAllAsync()
        {
            return ProviderAsync.GetAllAsync<T>();
        }

        public IList<T> GetFiltered(object filter)
        {
            return Provider.GetFiltered<T>(filter);
        }

        public T GetById(object id)
        {
            return Provider.GetById<T>(id);
        }

        public Task<List<T>> GetFilteredAsync(object filter)
        {
            return ProviderAsync.GetFilteredAsync<T>(filter);
        }

        public Task<T> GetByIdAsync(object id)
        {
            return ProviderAsync.GetByIdAsync<T>(id);
        }

        #endregion
    }
}
