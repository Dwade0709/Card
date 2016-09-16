using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Card.Core
{
    /// <summary>
    /// Builder abstract for creating Card Deck
    /// </summary>
    internal abstract class DeckBuilder
    {
        public ICardDeck CardDeck;

        protected XDocument ConfigDocument;

        protected DeckBuilder()
        {
            ConfigDocument = XDocument.Load("Cards.xml");
            CardDeck = new CardDeck();
            SetType();
            SetName();
        }

        protected void Creator(IEnumerable<XElement> elements, ICardFactory factory)
        {
            foreach (var role in elements)
                for (int i = 1; i <= Convert.ToInt32(role.Attribute(XName.Get("count")).Value); i++)
                    CardDeck.AddCard(factory.CreateCard(role.Attribute(XName.Get("name")).Value, role.Attribute(XName.Get("description")).Value, role.Attribute(XName.Get("weight")).Value));
        }

        public abstract void SetType();

        public abstract void SetName();

        public abstract void CreateCards(ICardFactory factory);
    }
}
