using System.Collections;
using System.Collections.Generic;

namespace CardsTable
{
    public class PlayersCollection : IEnumerable<Player>
    {
        private readonly List<Player> players = new ();
        private int currentPlayerIndex;

        public int Count => players.Count;

        public Player CurrentPlayer => players[currentPlayerIndex];

        public Player GoToNextPlayer()
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
            return CurrentPlayer;
        }

        public Player GoToPreviousPlayer()
        {
            currentPlayerIndex = (players.Count + currentPlayerIndex - 1) % players.Count;
            return CurrentPlayer;
        }

        public void Add(Player player)
        {
            players.Add(player);
        }

        public void Remove(Player player)
        {
            players.Remove(player);
        }

        public IEnumerator<Player> GetEnumerator()
        {
            return players.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}