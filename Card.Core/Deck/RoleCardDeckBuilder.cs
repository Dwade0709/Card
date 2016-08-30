using System.Xml.XPath;

// ReSharper disable once CheckNamespace
namespace Card.Core
{
    internal class RoleCardDeckBuilder : DeckBuilder
    {
        public override void CreateCards(ICardFactory factory)
        {
            Creator(ConfigDocument.XPathSelectElements("//roles/*"), factory);
        }

        public override void SetType()
        {
            CardDeck.DeckType = Enum.CardDeckEnum.ROLE_DECK;
        }

        public override void SetName()
        {
            CardDeck.Name = Enum.CardDeckEnum.ROLE_DECK.ToString();
        }
    }
}
