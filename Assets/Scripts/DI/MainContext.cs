using CardsTable.Settings;
using CardsTable.Gameplay;
using CardsTable.Gameplay.State;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using CardsTable.Gameplay.Mode;
using CardsTable.PlayingCard.DI;
using CardsTable.Player.DI;

namespace CardsTable.DI
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
            InstallCards(builder);
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

        private void InstallCards(IContainerBuilder builder)
        {
            builder.Register<Shuffler>(Lifetime.Singleton);
            builder.Register<CardFactory>(Lifetime.Singleton);
            builder.Register<DeckFactory>(Lifetime.Singleton);
        }
    }
}
