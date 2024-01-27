using System;

namespace CardsTable.UserState
{
    [Serializable]
    public struct UserStateData
    {
        public string nickname;
        public int totalScore;
        public bool isSfxMuted;
        public bool isAmbientMuted;

        public bool isValid;
    }
}