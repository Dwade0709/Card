using Card.Core.Enum;
using System.Collections.Generic;
using System.Linq;

namespace Card.Core
{
    public class CardGame : ICardGame
    {
        public IList<ICardDeck> CardsDecks { get; set; }

        public void Init()
        {
            DeckBuilder builder = new RoleCardDeckBuilder();
            builder.CreateCards();
            CardsDecks.Add(builder.CardDeck);
            builder = new GameCardDeckBuilder();
            builder.CreateCards();
            CardsDecks.Add(builder.CardDeck);
            builder = new PlayingCardDeckBuilder();
            builder.CreateCards();
            CardsDecks.Add(builder.CardDeck);
        }

        public ICard PassCards(CardDeckEnum cardDeskType)
        {
            var cardDesk = CardsDecks.Single(p => p.DeckType == cardDeskType);
            return cardDesk.GetRandomCard();
        }
    }
}
