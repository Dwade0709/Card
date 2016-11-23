using System;
using Core.Public;
using Server.Service.DataModel;

namespace Server.Service.Implementation
{
    public class UserService : IUserService
    {
        public IUser Login(string name, string password)
        {
            return new UserDataModel() { Name = name };
        }

        public IUser Create()
        {
            throw new NotImplementedException();
        }
    }
}
