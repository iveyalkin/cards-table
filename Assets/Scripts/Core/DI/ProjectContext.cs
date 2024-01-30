using CardsTable.UserState;
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
            builder.Register<UserStateStorage>(Lifetime.Singleton);
            builder.Register<UserStateRepository>(Lifetime.Singleton);
        }
    }
}
