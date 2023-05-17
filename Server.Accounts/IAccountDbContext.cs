using MongoDB.Driver;

namespace Server.Accounts
{
    public interface IAccountDbContext
    {
        MongoClient Client { get; set; }

        IMongoDatabase AccountDatabase { get; set; }
    }
}
