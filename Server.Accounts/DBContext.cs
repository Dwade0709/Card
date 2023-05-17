using Core.Services;
using MongoDB.Driver;


namespace Server.Accounts
{
    public class AccountDbContext : IAccountDbContext
    {
        private readonly ILoggerService _logger;

        public MongoClient Client { get; set; }

        public IMongoDatabase AccountDatabase { get; set; }

        public AccountDbContext(ILoggerService logger, string connectionStr)
        {
            _logger = logger;
            try
            {
                Client = new MongoClient(connectionStr);
                AccountDatabase = Client.GetDatabase("accounts");
            }
            catch (MongoException ex)
            {
                _logger.Error(ex);
            }
        }
    }
}
