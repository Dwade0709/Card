using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card.Core
{
    internal class GameCardDeckBuilder : DeckBuilder
    {
        public override void CreateCards(CardFactory factory)
        {
            CardDeck.AddCard(factory.CreateCard());
        }

        public override void SetType()
        {
            CardDeck.DeckType = Enum.CardDeckEnum.GAME_CARD_DECK;
        }
    }
}
