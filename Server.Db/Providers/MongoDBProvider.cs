using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Server.Db.DataModel;

namespace Server.Db.Providers
{
    public class MongoDBProvider<T> : IMongoDbProvider
    {
        #region [ .ctor & vars]

        private readonly string _dataBaseName;

        private readonly string _tableName;

        public MongoDBProvider(string connectionString)
        {
            var attributes = typeof(T).GetTypeInfo().CustomAttributes;

            if (!char.IsDigit(connectionString.TrimEnd('/').ToCharArray().Last()))
                _dataBaseName = connectionString.Remove(0, connectionString.LastIndexOf('/')).Trim('/');

            foreach (var customAttributeData in attributes)
            {
                if (customAttributeData.AttributeType.ToString() == typeof(DatabaseNameAttribute).ToString())
                    _dataBaseName = customAttributeData.ConstructorArguments[0].Value.ToString();
                if (customAttributeData.AttributeType.ToString() == typeof(TableAttribute).ToString())
                    _tableName = customAttributeData.ConstructorArguments[0].Value.ToString();
            }

            Client = new MongoClient(connectionString);
            Database = Client.GetDatabase(_dataBaseName);

        }
        #endregion

        #region  [ IMongoDbProvider field ]

        public MongoClient Client { get; set; }

        public IMongoDatabase Database { get; set; }

        #endregion

        #region  [ IDbProvider field ]

        public void Create<T>(T obj)
        {
            if (((IEntity<ObjectId>)obj).Id == ObjectId.Empty)
                ((IEntity<ObjectId>)obj).Id = ObjectId.GenerateNewId();
            Database.GetCollection<T>(typeof(T).Name).InsertOne(obj);
        }

        public void CreateOrUpdate<T>(T obj)
        {
            if (((IEntity<ObjectId>)obj).Id == ObjectId.Empty)
                ((IEntity<ObjectId>)obj).Id = ObjectId.GenerateNewId();
            Database.GetCollection<T>(typeof(T).Name).ReplaceOne(p => ((IEntity<ObjectId>)p).Id == ((IEntity<ObjectId>)obj).Id, obj, new UpdateOptions() { IsUpsert = true });
        }

        public bool Remove(object objectId)
        {
            var deleteResult = Database.GetCollection<BsonDocument>(_tableName).DeleteMany(new BsonDocument() { { "_id", new ObjectId(objectId.ToString()) } });
            return deleteResult.DeletedCount > 0;
        }

        public IList<T> GetAll<T>()
        {
            return Database.GetCollection<T>(typeof(T).Name).Find(_ => true).ToList();
        }

        public IList<T> GetFiltered<T>(object filter)
        {
            return Database.GetCollection<T>(_tableName).FindSync((BsonDocument)filter).ToList();
        }

        public T GetById<T>(object id)
        {
            return Database.GetCollection<T>(_tableName).FindSync(new BsonDocument() { { "_id", new ObjectId(id.ToString()) } }).FirstOrDefault();
        }

        #endregion

        #region  [ IDbProviderAsync field ]

        public void CreateAsync<T>(T obj)
        {
            if (((IEntity<ObjectId>)obj).Id == ObjectId.Empty)
                ((IEntity<ObjectId>)obj).Id = ObjectId.GenerateNewId();
            Database.GetCollection<T>(typeof(T).Name).InsertOneAsync(obj);
        }

        public void CreateOrUpdateAsync<T>(T obj)
        {
            if (((IEntity<ObjectId>)obj).Id == ObjectId.Empty)
                ((IEntity<ObjectId>)obj).Id = ObjectId.GenerateNewId();
            Database.GetCollection<T>(typeof(T).Name).ReplaceOneAsync(p => ((IEntity<ObjectId>)p).Id == ((IEntity<ObjectId>)obj).Id, obj, new UpdateOptions() { IsUpsert = true });
        }

        public Task<List<T>> GetAllAsync<T>()
        {
            return Database.GetCollection<T>(typeof(T).Name).Find(_ => true).ToListAsync();
        }

        public Task<List<T>> GetFilteredAsync<T>(object filter)
        {
            return Database.GetCollection<T>(_tableName).FindSync((BsonDocument)filter).ToListAsync();
        }

        public Task<T> GetByIdAsync<T>(object id)
        {
            return Database.GetCollection<T>(_tableName).FindSync(new BsonDocument() { { "_id", new ObjectId(id.ToString()) } }).FirstOrDefaultAsync();
        }

        public async Task<bool> RemoveAsync(object objectId)
        {
            Database.GetCollection<BsonDocument>(_tableName).DeleteManyAsync(new BsonDocument() { { "_id", new ObjectId(objectId.ToString()) } });
            return true;
        }

        #endregion
    }
}