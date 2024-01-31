using CardsTable.Gameplay.Mode;
using CardsTable.Player;

namespace CardsTable.Gameplay
{
    public class GameplayModel
    {
        private readonly GameplayMode gameplayMode = GameplayMode.PvP;
        private readonly PlayersCollection players = new();

        public bool isGameStarted;

        public PlayersCollection Players => players;

        public GameplayModel(GameplayMode gameplayMode, PlayersCollection players)
        {
            this.gameplayMode = gameplayMode;
            this.players = players;
        }
    }
}