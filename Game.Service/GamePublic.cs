using Game.Core;
using Game.Interfaces;
using Core.Interfaces;
using Core;
using Card.Core;
using System.Collections.Generic;

namespace Game.Service
{
    internal class GamePublic : IGamePublic
    {
        public IGame InitGame()
        {
            return CoreFactory.GetFactory<IGame>().Create<IGame>();
        }

        public void AddPlayer(IGame game, IPlayer player)
        {
            game.Players.Add(player);
        }

        public void TakeCard(IGame game)
        {
            IRandomizer randomizer = ServiceContainer.Instance.Get<IRandomizer>();
            foreach (var player in game.Players)
            {
                player.GameRole = randomizer.GetRandomObject<ICard>(game.GameRoleDeck.Cards());
                player.Role= randomizer.GetRandomObject<ICard>(game.RoleCards.Cards());
            }
        }
    }
}
