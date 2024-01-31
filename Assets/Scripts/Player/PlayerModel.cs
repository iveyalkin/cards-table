using System;
using CardsTable.Player.Hand;
using CardsTable.PlayingCard;

namespace CardsTable.Player
{
    public class PlayerModel
    {
        private readonly HandModel handModel;

        private PlayerState playerState;

        public string GameId => playerState.gameId;
        public int Score => playerState.score;

        public bool HasStartCardsCount => handModel.HasStartCardsCount;

        public event Action<CardData> OnCardAdded
        {
            add => handModel.OnCardAdded += value;
            remove => handModel.OnCardAdded -= value;
        }

        public event Action<CardData> OnCardRemoved
        {
            add => handModel.OnCardRemoved += value;
            remove => handModel.OnCardRemoved -= value;
        }

        public PlayerModel(PlayerState playerState, HandModel handModel)
        {
            this.handModel = handModel;
            this.playerState = playerState;
        }

        public void AddScore(int score)
        {
            playerState.score += score;
        }

        public void AddCardToHand(CardData card)
        {
            handModel.AddCard(card);
        }

        public void RemoveCardFromHand(CardData card)
        {
            handModel.RemoveCard(card);
        }
    }
}