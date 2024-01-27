using CardsTable.UserState;
using VContainer;

namespace CardsTable.Player.DI
{
    public class PlayerFactory
    {
        private readonly IObjectResolver objectResolver;

        public PlayerFactory(IObjectResolver objectResolver)
        {
            this.objectResolver = objectResolver;
        }

        public PlayerModel Create(UserStateData userStateData)
        {
            return new PlayerModel(userStateData.nickname, 0, objectResolver.Resolve<Hand>());
        }
    }
}