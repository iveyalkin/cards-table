using CardsTable.Settings;
using VContainer;
using VContainer.Unity;

namespace CardsTable.PlayingCard
{
    public class CardViewFactory
    {
        private readonly IObjectResolver objectResolver;
        private readonly CardDeckSettings deckSettings;

        public CardViewFactory(IObjectResolver objectResolver, CardDeckSettings deckSettings)
        {
            this.objectResolver = objectResolver;
            this.deckSettings = deckSettings;
        }

        public CardModel Create(CardData data)
        {
            var context = objectResolver.Instantiate(deckSettings.CardPrefab);

            // todo: deal with side effects, i.e. instantiated card prefab GO
            var model = context.Container.Resolve<CardModel>();

            // workaround for VContainer's limitation i.e. cannot inject CardData even with a subScopedContainer
            model.Data = data;

            return model;
        }
    }
}