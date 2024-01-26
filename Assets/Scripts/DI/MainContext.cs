using CardsTable.Settings;
using CardsTable.Gameplay;
using CardsTable.Gameplay.State;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using CardsTable.Gameplay.Mode;

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

            InstallCards(builder);
        }

        private void InstallGameplay(IContainerBuilder builder)
        {
            builder.Register<GameplayModeLoader>(Lifetime.Singleton);
            builder.RegisterEntryPoint<GameplayController>(Lifetime.Singleton);
            builder.Register<GameplayState>(Lifetime.Singleton);
        }


        private void InstallGameplaySettings(IContainerBuilder builder)
        {
            builder.RegisterInstance(gameplaySettings.SessionSettings);
            builder.RegisterInstance(gameplaySettings.DeckSettings);
            builder.RegisterInstance(gameplaySettings.HandSettings);
        }

        private void InstallCards(IContainerBuilder builder)
        {
            builder.Register<Shuffler>(Lifetime.Singleton);

            builder.RegisterFactory(() => new Deck());
            builder.Register<Table.Factory>(Lifetime.Singleton);
        }

    }
}
