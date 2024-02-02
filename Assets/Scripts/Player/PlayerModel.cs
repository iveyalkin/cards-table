using System;
using CardsTable.Player.Hand;
using CardsTable.PlayingCard;
using Cysharp.Threading.Tasks;

namespace CardsTable.Player
{
    public class PlayerModel
    {
        private readonly HandModel handModel;

        private PlayerState playerState;
        private TurnState turnState;

        public string GameId => playerState.gameId;
        public int Score => playerState.score;
        public bool IsLocalUser => playerState.isLocalUser;

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

        public event Action OnPlayerTurn = delegate { };

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
            card.isFaceUp = IsLocalUser;

            handModel.AddCard(card);
        }

        public void RemoveCardFromHand(CardData card)
        {
            handModel.RemoveCard(card);
        }

        public UniTask StartTurn()
        {
            if (turnState.IsValid)
                return turnState.TurnCompletionTask;

            turnState = new TurnState
            {
                turnCompletionSource = new UniTaskCompletionSource(),
            };

            handModel.IsActiveHand = true;

            OnPlayerTurn();

            return turnState.TurnCompletionTask;
        }

        public void EndTurn()
        {
            handModel.IsActiveHand = false;
            turnState.CompleteTurn();
        }

        private struct TurnState
        {
            public UniTaskCompletionSource turnCompletionSource;

            public bool IsValid => turnCompletionSource != null;
            public UniTask TurnCompletionTask => turnCompletionSource.Task;
            public void CompleteTurn()
            {
                if (!IsValid)
                    return;

                turnCompletionSource.TrySetResult();
                turnCompletionSource = null;
            }
        }
    }
}