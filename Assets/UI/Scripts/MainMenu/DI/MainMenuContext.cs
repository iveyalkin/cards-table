using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

namespace CardsTable.UI.MainMenu.DI
{
    public class MainMenuContext : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<UIDocument>().UnderTransform(transform);
            builder.Register<MainMenuView>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();
            builder.RegisterEntryPoint<MainMenuController>(Lifetime.Singleton);
        }
    }
}
