using System;
using UnityEngine;
using VContainer.Unity;

namespace CardsTable.Player
{
    public class PlayerController: IPostInitializable, IDisposable
    {
        private readonly PlayerModel model;

        public PlayerController(PlayerModel model)
        {
            this.model = model;
        }

        void IPostInitializable.PostInitialize()
        {
            model.OnPlayerTurn += PlayTurn;
        }

        void IDisposable.Dispose()
        {
            model.OnPlayerTurn -= PlayTurn;
        }

        public void PlayTurn()
        {
            Debug.Log($"Player '{model.GameId}' turn");
        }
    }
}
