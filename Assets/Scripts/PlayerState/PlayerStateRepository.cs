namespace CardsTable.PlayerState
{
    public class PlayerStateRepository
    {
        private readonly PlayerStateStorage playerStateStorage;

        private PlayerStateData cachedPlayerState;

        public PlayerStateRepository(PlayerStateStorage playerStateStorage)
        {
            this.playerStateStorage = playerStateStorage;
        }

        public PlayerStateData GetPlayerState()
        {
            if (!cachedPlayerState.isValid)
            {
                cachedPlayerState = playerStateStorage.LoadPlayerState();
            }

            return cachedPlayerState;
        }
    }
}