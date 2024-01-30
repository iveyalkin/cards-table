using CardsTable.Settings;
using CardsTable.Gameplay;
using CardsTable.Gameplay.State;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using CardsTable.Gameplay.Mode;
using CardsTable.Player.DI;
using CardsTable.CardDeck;
using CardsTable.PlayingCard;

namespace CardsTable.Core.DI
{
    public class MainContext : LifetimeScope
    {
        [SerializeField]
        private GameplaySettings gameplaySettings;

        protected override void Configure(IContainerBuilder builder)
        {
            InstallGameplaySettings(builder);
            InstallGameplay(builder);
            InstallPlayer(builder);
            InstallTable(builder);
            InstallCardsDeck(builder);
        }

        private void InstallGameplaySettings(IContainerBuilder builder)
        {
            builder.RegisterInstance(gameplaySettings.SessionSettings);
            builder.RegisterInstance(gameplaySettings.DeckSettings);
            builder.RegisterInstance(gameplaySettings.HandSettings);
        }

        private void InstallGameplay(IContainerBuilder builder)
        {
            builder.Register<GameplayModeLoader>(Lifetime.Singleton);
            builder.Register<GameplayController>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();
            builder.Register<GameplayState>(Lifetime.Singleton);
        }

        private void InstallPlayer(IContainerBuilder builder)
        {
            builder.Register<Hand>(Lifetime.Transient);
            builder.Register<PlayerFactory>(Lifetime.Singleton);
        }

        private void InstallTable(IContainerBuilder builder)
        {
            builder.Register<Table.Factory>(Lifetime.Singleton);
        }

        private void InstallCardsDeck(IContainerBuilder builder)
        {
            builder.Register<Shuffler>(Lifetime.Singleton);
            builder.Register<CardDeckFactory>(Lifetime.Singleton);
        }
    }
}
