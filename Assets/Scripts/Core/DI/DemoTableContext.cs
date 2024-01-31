using CardsTable.Gameplay;
using CardsTable.Gameplay.Mode;
using CardsTable.Player;
using CardsTable.UserState;
using CradsTable.Core.DI;
using VContainer;
using VContainer.Unity;

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
            }, Lifetime.Scoped);

            builder.RegisterComponentInHierarchy<CardSlotView>();

            InstallGameplay(builder);
            InstallCardsDeck(builder);
            // InstallTable(builder);
        }
    }
}