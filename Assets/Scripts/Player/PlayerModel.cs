using CardsTable.PlayingCard;

namespace CardsTable.Player
{
    public class PlayerModel
    {
        private readonly Hand hand;
        private readonly string gameId;

        private int score;

        public string GameId => gameId;
        public int Score => score;

        public bool HasStartCardsCount => hand.HasStartCardsCount;

        public PlayerModel(string gameId, int score, Hand hand)
        {
            this.gameId = gameId;
            this.hand = hand;
            this.score = score;
        }

        public void AddScore(int score)
        {
            this.score += score;
        }

        public void AddCardToHand(CardModel card)
        {
            hand.AddCard(card);
        }

        public void RemoveCardFromHand(CardModel card)
        {
            hand.RemoveCard(card);
        }
    }
}