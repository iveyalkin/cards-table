using CardsTable.Settings;
using VContainer.Unity;
using CardsTable.CardDeck;

namespace CardsTable.Gameplay
{
    public class GameplayController : IStartable, ITickable
    {
        private readonly SessionSettings sessionSettings;
        private readonly GameplayModel gameplayModel;
        private readonly CardDeckFactory deckFactory;

        public GameplayController(CardDeckFactory deckFactory, GameplayModel gameplayModel,
             SessionSettings sessionSettings)
        {
            this.sessionSettings = sessionSettings;
            this.deckFactory = deckFactory;
            this.gameplayModel = gameplayModel;
        }

        void IStartable.Start()
        {
            if (gameplayModel.isGameStarted)
            {
                EndGame();
            }

            var deck = deckFactory.Create();
            deck.Shuffle();

            PreparePlayers();

            gameplayModel.isGameStarted = true;
        }

        private void PreparePlayers()
        {
            foreach (var player in gameplayModel.Players)
            {
                    // todo: do smth like
                // while (!player.HasStartCardsCount)
                {
                    // var card = deck.DrawCard();
                    // player.AddCardToHand(card);
                }
            }
        }

        public void EndGame()
        {
            gameplayModel.isGameStarted = false;
        }

        public void PlayTurn()
        {
            
        }

        void ITickable.Tick()
        {
            if (!gameplayModel.isGameStarted)
            {
                return;
            }

            PlayTurn();
        }
    }
}
