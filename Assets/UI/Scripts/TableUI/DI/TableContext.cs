using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

namespace CardsTable.UI.TableUI.DI
{
    public class TableContext : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<UIDocument>();
            builder.RegisterEntryPoint<TableUIView>(Lifetime.Scoped);
            builder.RegisterEntryPoint<TableUIController>(Lifetime.Scoped);
        }
    }
}