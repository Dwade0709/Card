namespace Game.Core
{
    /// <summary>
    /// User states
    /// </summary>
    public abstract class AUserState
    {
        public abstract void Handle(IUser user);

        public abstract string Name();

        public abstract bool Online();
    }
    /// <summary>
    /// Online state
    /// </summary>
    internal class OnlineUserState : AUserState
    {
        public override void Handle(IUser user)
        {
            user.UserState = new OfflineUserState();
        }

        public override string Name()
        {
            return "Online";
        }

        public override bool Online()
        {
            return true;
        }
    }

    /// <summary>
    /// Offline state
    /// </summary>
    internal class OfflineUserState : AUserState
    {
        public override void Handle(IUser user)
        {
            user.UserState = new OnlineUserState();
        }

        public override string Name()
        {
            return "Offline";
        }

        public override bool Online()
        {
            return false;
        }
    }
}
