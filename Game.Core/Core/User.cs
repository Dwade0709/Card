namespace Game.Core
{
    internal class User : IUser
    {
        public User() { }

        public string Name { get; set; }

        public string Login { get; set; }

        public AUserState UserState { get; set; }
    }
}
