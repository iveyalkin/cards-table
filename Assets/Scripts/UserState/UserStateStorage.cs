using CardsTable.Player;

namespace CardsTable.UserState
{
    public class UserStateStorage
    {
        public UserStateData LoadPlayerState()
        {
            return new UserStateData
            {
                playerState = new PlayerState {
                    gameId = "Lurking Lynx",
                    score = 100
                },
                isValid = true
            };
        }
    }
}