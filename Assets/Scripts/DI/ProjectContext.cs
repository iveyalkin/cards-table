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
        }

        private void InstallPlayerState(IContainerBuilder builder)
        {
            builder.Register<PlayerStateStorage>(Lifetime.Singleton);
            builder.Register<PlayerStateRepository>(Lifetime.Singleton);
        }
    }
}
