using System;
using Card.Core;
using System.Collections.Generic;

namespace Game.Core
{
    internal class GameCore : IGame
    {
        private IList<IPlayer> _players;

        public ICardDeck _playingDeck;

        public ICardDeck _roleCards;

        public ICardDeck _gameRoleDeck;

        public GameCore()
        {
            if (_players == null)
                _players = new List<IPlayer>();
            if (_playingDeck == null)
                _playingDeck = DeckFacade.CreateDeck(Card.Core.Enum.CardDeckEnum.PLAYING_DECK);
            if (_roleCards == null)
                _roleCards = DeckFacade.CreateDeck(Card.Core.Enum.CardDeckEnum.ROLE_DECK);
            if (_gameRoleDeck == null)
                _gameRoleDeck = DeckFacade.CreateDeck(Card.Core.Enum.CardDeckEnum.GAME_CARD_DECK);
        }

        public IList<IPlayer> Players { get { return _players; } }

        public ICardDeck PlayingDeck { get { return _playingDeck; } }

        public ICardDeck RoleCards { get { return _roleCards; } }

        public ICardDeck GameRoleDeck { get { return _gameRoleDeck; } }
    }
}
