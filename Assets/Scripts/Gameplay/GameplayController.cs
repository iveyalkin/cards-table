using System;
using CardsTable.Settings;
using CardsTable.Gameplay.State;
using UnityEngine;
using UnityEngine.Assertions;
using VContainer.Unity;
using CardsTable.Player;

namespace CardsTable.Gameplay
{
    public class GameplayController : ITickable
    {
        private readonly SessionSettings sessionSettings;
        private readonly GameplayState gameState;
        private readonly Table.Factory tableFactory;
        private readonly DeckFactory deckFactory;

        private readonly PlayersCollection players = new();

        private Table currentTable;

        public GameplayController(Table.Factory tableFactory, DeckFactory deckFactory,
            GameplayState gameState, SessionSettings sessionSettings)
        {
            this.sessionSettings = sessionSettings;
            this.tableFactory = tableFactory;
            this.deckFactory = deckFactory;
            this.gameState = gameState;
        }

        public void AddPlayer(PlayerModel player) => players.Add(player);

        public void StartGame(Mode.GameplayMode gameMode)
        {
            if (gameState.isGameStarted)
            {
                EndGame();
            }

            var deck = deckFactory.Create();

            deck.Shuffle();

            foreach (var player in players)
            {
                while (!player.HasStartCardsCount)
                {
                    var card = deck.DrawCard();
                    player.AddCardToHand(card);
                }
            }

            var playersCount = Mathf.Max(1, players.Count);

            Assert.IsTrue(playersCount <= sessionSettings.MaxPlayersCount);

            var tableSettings = sessionSettings.TableSettings[playersCount];
            currentTable = tableFactory.Create(tableSettings, players, deck);

            gameState.gameplayMode = gameMode;
            gameState.isGameStarted = true;
        }

        public void EndGame()
        {
            gameState.isGameStarted = false;
        }

        public void PlayTurn()
        {
            
        }

        void ITickable.Tick()
        {
            if (!gameState.isGameStarted)
            {
                return;
            }

            PlayTurn();
        }
    }
}
