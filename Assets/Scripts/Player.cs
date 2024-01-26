using System;

namespace CardsTable
{
    public class Player
    {
        private string gameId;
        private Hand hand;

        public string GameId => gameId;
        public bool HasStartCardsCount => hand.HasStartCardsCount;

        public Player(string gameId, Hand hand)
        {
            this.gameId = gameId;
            this.hand = hand;
        }


        public void AddCardToHand(Card card)
        {
            hand.AddCard(card);
        }

        public void RemoveCardFromHand(Card card)
        {
            hand.RemoveCard(card);
        }

        public void PlayTurn()
        {
            // Implement the logic for the player's turn here
        }

        // Other methods and properties specific to your card game can be added here
    }
}
