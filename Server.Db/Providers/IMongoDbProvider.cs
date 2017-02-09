using MongoDB.Driver;

namespace Server.Db.Providers
{
    public interface IMongoDbProvider : IDbProvider, IDbProviderAsync
    {
        MongoClient Client { get; set; }

        IMongoDatabase Database { get; set; }
    }
}
