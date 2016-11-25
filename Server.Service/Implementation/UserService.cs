using System;
using Core.Public;
using MongoDB.Bson;
using Server.Accounts;
using Server.Service.DataModel;

namespace Server.Service.Implementation
{
    internal class UserService : IUserService
    {
        private readonly IAccountDbContext _accountDbContext;

        public UserService()
        {
            _accountDbContext = new AccountDbContext();
        }

        public IUser Login(string name, string password)
        {
            var collection = _accountDbContext.AccountDatabase.GetCollection<BsonDocument>("account");
            var account = new AccountModel
            {
                AccounName = name,
                AccounPass = password
            };
            collection.InsertOneAsync(account.ToBsonDocument()).GetAwaiter().GetResult();

            return new UserDataModel() { Name = name };
        }

        public IUser Create()
        {
            throw new NotImplementedException();
        }
    }
}
