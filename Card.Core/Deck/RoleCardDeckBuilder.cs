using System;

namespace Card.Core
{
    internal class RoleCardDeckBuilder : DeckBuilder
    {
        public override void CreateCards(CardFactory factory)
        {
            CardDeck.AddCard(factory.CreateCard());
        }

        public override void SetType()
        {
            CardDeck.DeckType = Enum.CardDeckEnum.ROLE_DECK;
        }
    }
}
