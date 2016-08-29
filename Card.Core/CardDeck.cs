using System.Collections.Generic;
using Card.Core.Enum;

namespace Card.Core
{
    internal class CardDeck : ICardDeck
    {
        private IList<ICard> _cards;

        protected internal CardDeck()
        {
            if (_cards == null)
                _cards = new List<ICard>();
        }

        public string Name { get; set; }

        public CardDeckEnum DeckType { get; set; }

        public void AddCard(ICard card)
        {
            _cards.Add(card);
        }

        public void RemoveCard(ICard card)
        {
            _cards.Remove(card);
        }
    }
}
