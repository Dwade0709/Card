using Card.Core.Enum;
using System.Collections.Generic;
using System.Linq;

namespace Card.Core
{
    public class CardGame : ICardGame
    {
        private IList<ICardDeck> _cardsDecks;

        public IList<ICardDeck> CardsDecks
        {
            get
            {
                if (_cardsDecks == null)
                    _cardsDecks = new List<ICardDeck>();
                return _cardsDecks;
            }
        }

        public void Init()
        {
            //DeckBuilder builder = new RoleCardDeckBuilder();
            //builder.CreateCards(Card.Card.GetFactory(RoleCard));
            //CardsDecks.Add(builder.CardDeck);
            //builder = new GameCardDeckBuilder();
            //builder.CreateCards(new GameCardFactory());
            //CardsDecks.Add(builder.CardDeck);
            //builder = new PlayingCardDeckBuilder();
            //builder.CreateCards(new PlayingCardFactory());
            //CardsDecks.Add(builder.CardDeck);
        }

        public ICard PassCards(CardDeckEnum cardDeskType)
        {
            //var cardDesk = CardsDecks.Single(p => p.DeckType == cardDeskType);
            //return cardDesk;
            return new Card.ACard();
        }
    }
}
