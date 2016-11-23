using Core.Public;

namespace Server.Service.DataModel
{
    internal class UserDataModel : IUser
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public bool IsOnline { get; set; }

        
    }
}
