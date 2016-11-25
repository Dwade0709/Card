using MongoDB.Driver;
using Server.Core;

namespace Server.Accounts
{
    public class AccountDbContext : IAccountDbContext
    {
        public MongoClient Client { get; set; }

        public IMongoDatabase AccountDatabase { get; set; }

        public AccountDbContext()
        {
            try
            {
                Client = new MongoClient(GlobalFacade.Settings.AccountsDbConnection);
                AccountDatabase = Client.GetDatabase("accounts");
            }
            catch (MongoException ex)
            {
                GlobalFacade.LoggerService.Error(ex);
            }
        }
    }
}
