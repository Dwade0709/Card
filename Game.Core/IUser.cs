namespace Game.Core
{
    public interface IUser
    {
        string Name { get; set; }

        string Login { get; set; }

        AUserState UserState { get; set; }
    }
}
