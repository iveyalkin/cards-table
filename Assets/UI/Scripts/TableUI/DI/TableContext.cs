using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

namespace CardsTable.UI.TableUI.DI
{
    public class TableContext : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<UIDocument>().UnderTransform(transform);

            builder.Register<TableUIView>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();
            builder.RegisterEntryPoint<TableUIController>(Lifetime.Singleton);
        }
    }
}