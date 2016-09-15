using Game.Core;

namespace Game.Interfaces
{
    public interface IGamePublic
    {
        IGame InitGame();

        void AddPlayer(IGame game, IPlayer player);

        void TakeCard(IGame game);

    }
}
