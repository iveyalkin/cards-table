using CardsTable;
using CardsTable.CardDeck;
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
            InstallCardsDeck(builder);
            InstallTable(builder);
        }

        protected void InstallGameplay(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameplayController>(Lifetime.Singleton);
            builder.RegisterEntryPoint<GameplayModel>(Lifetime.Singleton)
                .AsSelf();
        }

        protected void InstallCardsDeck(IContainerBuilder builder)
        {
            builder.Register<Shuffler>(Lifetime.Singleton);
            builder.Register<CardDeckFactory>(Lifetime.Singleton);
        }

        protected void InstallTable(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<TableView>(Lifetime.Singleton)
                .WithParameter(tableUI);
            builder.Register<TableModel>(Lifetime.Singleton);
        }
    }
}
