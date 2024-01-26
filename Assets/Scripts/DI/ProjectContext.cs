using CardsTable.PlayerState;
using VContainer;
using VContainer.Unity;

namespace CradsTable.Core.DI
{
    public class ProjectContext : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            InstallPlayerState(builder);

            builder.Register<PlayerStateData>(Container => {
                // todo: make it explicit where state is requested
                var playerStateRepository = Container.Resolve<PlayerStateRepository>();
                return playerStateRepository.GetPlayerState();
            }, Lifetime.Singleton);
        }

        private void InstallPlayerState(IContainerBuilder builder)
        {
            builder.Register<PlayerStateStorage>(Lifetime.Singleton);
            builder.Register<PlayerStateRepository>(Lifetime.Singleton);
        }
    }
}
