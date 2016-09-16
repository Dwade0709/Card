// ReSharper disable once CheckNamespace
namespace Card.Core
{
    public interface ICardFactory
    {
        ICard CreateCard(string name, string description, object weight);
    }
}
