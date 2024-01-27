using CardsTable.PlayingCard;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

namespace CardsTable.UI.PlayingCard.DI
{
    public class CardContext : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<UIDocument>().UnderTransform(transform);

            builder.Register<CardView>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.RegisterEntryPoint<CardController>(Lifetime.Scoped);
        }
    }
}