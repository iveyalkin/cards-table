using CardsTable.Settings;
using VContainer.Unity;
using Cysharp.Threading.Tasks;

namespace CardsTable.Gameplay
{
    public class GameplayController : IAsyncStartable
    {
        private readonly SessionSettings sessionSettings;
        private readonly GameplayModel gameplayModel;

        public GameplayController(GameplayModel gameplayModel, SessionSettings sessionSettings)
        {
            this.sessionSettings = sessionSettings;
            this.gameplayModel = gameplayModel;
        }

        async UniTask IAsyncStartable.StartAsync(System.Threading.CancellationToken cancellation)
        {
            if (gameplayModel.isGameStarted)
            {
                EndGame();
            }

            gameplayModel.CardDeckModel.Shuffle();

            // gives some time to unity to render the UI
            await UniTask.NextFrame(cancellation);

            PreparePlayers();

            gameplayModel.isGameStarted = true;

            GameLoop().Forget();
        }

        private void PreparePlayers()
        {
            foreach (var player in gameplayModel.Players)
            {
                while (!player.HasStartCardsCount)
                {
                    var card = gameplayModel.CardDeckModel.DrawCard();
                    player.AddCardToHand(card);
                }
            }
        }

        public void EndGame()
        {
            gameplayModel.isGameStarted = false;
        }

        private async UniTask PlayTurn()
        {
            foreach (var player in gameplayModel.Players)
            {
                await player.StartTurn();
            }
        }

        private async UniTaskVoid GameLoop()
        {
            while (gameplayModel.isGameStarted)
            {
                await PlayTurn();
            }
        }
    }
}
