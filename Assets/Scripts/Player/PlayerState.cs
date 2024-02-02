using System;

namespace CardsTable.Player
{
    [Serializable]
    public struct PlayerState
    {
        public string gameId;
        public bool isLocalUser;
        public int score;
    }
}