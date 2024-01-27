namespace CardsTable.UserState
{
    public class UserStateStorage
    {
        public UserStateData LoadPlayerState()
        {
            return new UserStateData
            {
                nickname = "Lurking Lynx",
                totalScore = 100,
                isValid = true
            };
        }
    }
}