using Core.Public;

namespace Server.Service
{
    public interface IUserService
    {
        IUser Login(string name,string password);

        IUser Create();
    }
}
