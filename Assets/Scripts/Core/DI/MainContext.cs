using CardsTable.Settings;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using CardsTable.Gameplay.Mode;
using CardsTable.Player;

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
        }

        private void InstallPlayer(IContainerBuilder builder)
        {
            builder.Register<HandModel>(Lifetime.Transient);
            builder.Register<PlayerFactory>(Lifetime.Singleton);
        }
    }
}
