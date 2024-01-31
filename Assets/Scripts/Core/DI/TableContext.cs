using CardsTable.Gameplay;
using CardsTable.Table;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

namespace CradsTable.Core.DI
{
    public class TableContext : LifetimeScope
    {
        [SerializeField]
        private UIDocument tableUI;
        
        protected override void Configure(IContainerBuilder builder)
        {
            InstallGameplay(builder);
            InstallTable(builder);
        }

        protected void InstallGameplay(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameplayController>(Lifetime.Singleton);
            builder.RegisterEntryPoint<GameplayModel>(Lifetime.Singleton)
                .AsSelf();
        }

        protected void InstallTable(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<TableView>(Lifetime.Singleton)
                .WithParameter(tableUI);
            builder.Register<TableModel>(Lifetime.Singleton);
        }
    }
}
