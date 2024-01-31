using CardsTable.Settings;
using VContainer;
using VContainer.Unity;

namespace CardsTable.PlayingCard
{
    public class CardViewFactory
    {
        private readonly CardDeckSettings deckSettings;
        private readonly LifetimeScope lifetimeScope;

        public CardViewFactory(CardDeckSettings deckSettings, LifetimeScope lifetimeScope)
        {
            this.deckSettings = deckSettings;
            this.lifetimeScope = lifetimeScope;
        }

        public CardModel Create(CardData data)
        {
            var context = lifetimeScope.CreateChildFromPrefab(deckSettings.CardPrefab, (builder) => builder.RegisterInstance(data));
            return context.Container.Resolve<CardModel>();
        }
    }
}