using VContainer;
using VContainer.Unity;

namespace CardsTable.Player
{
    public class PlayerContext : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<PlayerModel>(Lifetime.Singleton);
            builder.RegisterEntryPoint<PlayerController>(Lifetime.Singleton);
        }
    }
}