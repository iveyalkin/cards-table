using CardsTable.CardDeck;
using CardsTable.Gameplay.Mode;
using CardsTable.Player;

namespace CardsTable.Gameplay
{
    public class GameplayModel
    {
        private readonly GameplayMode gameplayMode = GameplayMode.PvP;
        private CardDeckModel cardDeckModel;
        private readonly PlayersCollection players = new();

        public bool isGameStarted;

        public PlayersCollection Players => players;
        public CardDeckModel CardDeckModel => cardDeckModel;

        public GameplayModel(GameplayMode gameplayMode, CardDeckModel cardDeckModel,
             PlayersCollection players)
        {
            this.gameplayMode = gameplayMode;
            this.players = players;
            this.cardDeckModel = cardDeckModel;
        }
    }
}