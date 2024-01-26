using CardsTable.Settings;
using CardsTable.State;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CardsTable.DI
{
    public class MainContext : LifetimeScope
    {
        [SerializeField]
        private GameplaySettings gameplaySettings;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(gameplaySettings.SessionSettings);
            builder.RegisterInstance(gameplaySettings.DeckSettings);
            builder.RegisterInstance(gameplaySettings.HandSettings);

            builder.RegisterEntryPoint<GameController>(Lifetime.Singleton);
            builder.Register<GameplayState>(Lifetime.Singleton);

            builder.Register<Shuffler>(Lifetime.Singleton);

            builder.RegisterFactory(() => new Deck());
            builder.Register<Table.Factory>(Lifetime.Singleton);
        }
    }
}
