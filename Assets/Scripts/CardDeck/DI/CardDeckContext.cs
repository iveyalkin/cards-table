using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

namespace CardsTable.CardDeck.DI
{
    public class CardDeckContext : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<UIDocument>().UnderTransform(transform);

            builder.RegisterEntryPoint<CardDeckView>(Lifetime.Singleton).AsSelf();
            builder.Register<CardDeckModel>(Lifetime.Singleton);
            builder.RegisterEntryPoint<CardDeckController>(Lifetime.Singleton);
        }
    }
}