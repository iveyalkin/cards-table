using CardsTable.Settings;
using CardsTable.UserState;
using VContainer;
using VContainer.Unity;

namespace CardsTable.Player
{
    public class PlayerFactory
    {
        private readonly LifetimeScope lifetimeScope;
        private readonly HandSettings handSettings;

        public PlayerFactory(LifetimeScope lifetimeScope, HandSettings handSettings)
        {
            this.lifetimeScope = lifetimeScope;
            this.handSettings = handSettings;
        }

        public PlayerModel Create(UserStateData userStateData)
        {
            var context = lifetimeScope.CreateChildFromPrefab(handSettings.PlayerPrefab,
                builder => builder.RegisterInstance(userStateData.playerState));
            context.Build();
            return context.Container.Resolve<PlayerModel>();
        }
    }
}