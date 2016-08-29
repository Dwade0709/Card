using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Card.Core
{
    /// <summary>
    /// Builder abstract for creating Card Deck
    /// </summary>
    abstract class DeckBuilder
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

        protected void Creator(IEnumerable<XElement> elements, CardFactory factory)
        {
            foreach (var role in elements)
                for (int i = 1; i <= Convert.ToInt32(role.Attribute(XName.Get("count")).Value); i++)
                    CardDeck.AddCard(factory.CreateCard(role.Attribute(XName.Get("name")).Value, role.Attribute(XName.Get("description")).Value, role.Attribute(XName.Get("count")).Value));
        }

        public abstract void SetType();

        public abstract void SetName();

        public abstract void CreateCards(CardFactory factory);
    }
}
