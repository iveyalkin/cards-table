using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

namespace CardsTable.UI.MainMenu.DI
{
    public class MainMenuContext : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<UIDocument>();
            builder.RegisterEntryPoint<MainMenuController>(Lifetime.Scoped);
        }
    }
}
