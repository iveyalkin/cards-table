namespace CardsTable.PlayerState
{
    public class PlayerStateStorage
    {
        public PlayerStateData LoadPlayerState()
        {
            return new PlayerStateData
            {
                nickname = "Lurking Lynx",
                totalScore = 100,
                isValid = true
            };
        }
    }
}