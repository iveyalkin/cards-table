using CardsTable.Player.Hand;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

namespace CardsTable.Player
{
    public class PlayerContext : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<UIDocument>().UnderTransform(transform);

            builder.RegisterEntryPoint<HandView>(Lifetime.Singleton).AsSelf();
            builder.RegisterEntryPoint<HandController>(Lifetime.Singleton);
            builder.Register<HandModel>(Lifetime.Singleton);

            builder.Register<PlayerModel>(Lifetime.Singleton);
            builder.RegisterEntryPoint<PlayerController>(Lifetime.Singleton);
        }
    }
}