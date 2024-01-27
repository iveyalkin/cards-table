namespace CardsTable.UserState
{
    public class UserStateRepository
    {
        private readonly UserStateStorage playerStateStorage;

        private UserStateData cachedPlayerState;

        public UserStateRepository(UserStateStorage playerStateStorage)
        {
            this.playerStateStorage = playerStateStorage;
        }

        public UserStateData GetState()
        {
            if (!cachedPlayerState.isValid)
            {
                cachedPlayerState = playerStateStorage.LoadPlayerState();
            }

            return cachedPlayerState;
        }
    }
}