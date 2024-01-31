using System;
using VContainer.Unity;

namespace CardsTable.Player
{
    public class PlayerController: IInitializable, IDisposable
    {
        private readonly PlayerModel playerModel;

        public PlayerController(PlayerModel playerModel)
        {
            this.playerModel = playerModel;
        }

        void IInitializable.Initialize()
        {
        }

        void IDisposable.Dispose()
        {
        }

        public void PlayTurn()
        {
            
        }
    }
}
