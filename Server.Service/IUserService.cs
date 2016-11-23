using Core.Public;

namespace Server.Service
{
    internal interface IUserService
    {
        IUser Login(string name,string password);

        IUser Create();
    }
}
