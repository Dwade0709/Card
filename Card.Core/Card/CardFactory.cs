// ReSharper disable once CheckNamespace
namespace Card.Core
{
    internal abstract class CardFactory
    {
        public abstract Card CreateCard(string name, string description, object weight);
    }
}
