using CardsTable.CardDeck;
using CardsTable.Gameplay.Mode;
using CardsTable.Player;
using CardsTable.UserState;
using CradsTable.Core.DI;
using VContainer;

namespace CardsTable.Core.DI
{
    public class DemoTableContext : TableContext
    {
        public GameplayMode gameplayMode;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(gameplayMode);

            builder.Register(container => {
                var userStateRepository = container.Resolve<UserStateRepository>();
                var playerFactory = container.Resolve<PlayerFactory>();
                var userState = userStateRepository.GetState();

                return new PlayersCollection
                {
                    playerFactory.Create(userState)
                };
            }, Lifetime.Singleton);

            builder.Register(Container => {
                var factory = Container.Resolve<CardDeckFactory>();
                return factory.Create();
            }, Lifetime.Singleton);

            builder.Register(container => {
                var userStateRepository = container.Resolve<UserStateRepository>();
                var userState = userStateRepository.GetState();

                return userState.playerState;
            }, Lifetime.Singleton);

            InstallGameplay(builder);
            // InstallTable(builder);
        }
    }
}