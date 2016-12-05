using System;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Server.Db.Providers
{
    // ReSharper disable once InconsistentNaming
    public class MongoDBProvider<Tobj> : IMongoDbProvider
    {
        private readonly string _dataBaseName;

        private readonly string _tableName;

        private MongoClient Client { get; set; }

        private IMongoDatabase Database { get; set; }

        public MongoDBProvider(string connectionString)
        {
            var attributes = typeof(Tobj).GetTypeInfo().CustomAttributes;

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

        public void Create<T>(T obj)
        {
            Database.GetCollection<T>(typeof(T).Name).InsertOne(obj);
        }

        public void CreateOrUpdate<T>(T obj) where T : IMongoDataModel
        {
            Database.GetCollection<T>(typeof(T).Name).ReplaceOne(p => p.Id == obj.Id, obj, new UpdateOptions() { IsUpsert = true });
        }

        public bool Remove<T>(T obj) where T : IMongoDataModel
        {
            var deleteResult = Database.GetCollection<T>(typeof(T).Name).DeleteOne(p => p.Id == obj.Id);
            return deleteResult.DeletedCount > 0;
        }

        public bool Remove(object objectId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Id", Convert.ToInt32(objectId));
            var deleteResult = Database.GetCollection<BsonDocument>(_tableName).DeleteMany(filter);
            return deleteResult.DeletedCount > 0;
        }

        public void CreateAsync<T>(T obj)
        {
            Database.GetCollection<T>(typeof(T).Name).InsertOneAsync(obj);
        }

        public void CreateOrUpdateAsync<T>(T obj) where T : IMongoDataModel
        {
            Database.GetCollection<T>(typeof(T).Name).ReplaceOneAsync(p => p.Id == obj.Id, obj, new UpdateOptions() { IsUpsert = true });
        }

        public void RemoveAsync<T>(T obj) where T : IMongoDataModel
        {
            Database.GetCollection<T>(typeof(T).Name).DeleteOneAsync(p => p.Id == obj.Id);
        }

        public void RemoveAsync(object objectId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Id", Convert.ToInt32(objectId));
            Database.GetCollection<BsonDocument>(_tableName).DeleteMany(filter);
        }

        public IList<T> GetAll<T>()
        {
            return Database.GetCollection<T>(typeof(T).Name).Find(null).ToList();
        }

        public Task<List<T>> GetAllAsync<T>()
        {
            return Database.GetCollection<T>(typeof(T).Name).Find(null).ToListAsync();
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
