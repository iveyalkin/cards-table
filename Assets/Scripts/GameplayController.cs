using System;
using System.Collections.Generic;
using CardsTable.Settings;
using CardsTable.State;
using UnityEngine;
using UnityEngine.Assertions;
using VContainer.Unity;

namespace CardsTable
{
    public class GameController : ITickable
    {
        private readonly SessionSettings sessionSettings;
        private readonly GameplayState gameState;
        private readonly Table.Factory tableFactory;
        private readonly Func<Deck> deckFactory;

        private readonly PlayersCollection players = new();
        private Table table;

        public GameController(Table.Factory tableFactory, Func<Deck> deckFactory,
            GameplayState gameState, SessionSettings sessionSettings)
        {
            this.sessionSettings = sessionSettings;
            this.tableFactory = tableFactory;
            this.deckFactory = deckFactory;
            this.gameState = gameState;
        }

        public void AddPlayer(Player player) => players.Add(player);

        public void StartGame()
        {
            var deck = deckFactory();

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
            table = tableFactory.Create(tableSettings, players, deck);
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
