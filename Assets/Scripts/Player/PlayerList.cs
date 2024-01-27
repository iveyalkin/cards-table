using System.Collections;
using System.Collections.Generic;

namespace CardsTable.Player
{
    public class PlayersCollection : IEnumerable<PlayerModel>
    {
        private readonly List<PlayerModel> players = new ();
        private int currentPlayerIndex;

        public int Count => players.Count;

        public PlayerModel CurrentPlayer => players[currentPlayerIndex];

        public PlayerModel GoToNextPlayer()
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
            return CurrentPlayer;
        }

        public PlayerModel GoToPreviousPlayer()
        {
            currentPlayerIndex = (players.Count + currentPlayerIndex - 1) % players.Count;
            return CurrentPlayer;
        }

        public void Add(PlayerModel player)
        {
            players.Add(player);
        }

        public void Remove(PlayerModel player)
        {
            players.Remove(player);
        }

        public IEnumerator<PlayerModel> GetEnumerator()
        {
            return players.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}