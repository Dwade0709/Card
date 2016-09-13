using Game.Core.Core;

namespace Game.Core
{
    internal abstract class APlayer : IPlayer
    {
        public string Name { get; set; }

        public IUser User { get; set; }


    }
}
