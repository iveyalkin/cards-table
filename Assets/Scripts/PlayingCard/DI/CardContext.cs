using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

namespace CardsTable.PlayingCard.DI
{
    public class CardContext : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<UIDocument>().UnderTransform(transform);

            builder.RegisterEntryPoint<CardView>(Lifetime.Singleton).AsSelf();
            builder.Register<CardModel>(Lifetime.Singleton);
            builder.RegisterEntryPoint<CardController>(Lifetime.Singleton);
        }
    }
}