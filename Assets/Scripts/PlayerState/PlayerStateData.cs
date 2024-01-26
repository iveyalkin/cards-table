using System;

namespace CardsTable.PlayerState
{
    [Serializable]
    public struct PlayerStateData
    {
        public string nickname;
        public int totalScore;
        public bool isSfxMuted;
        public bool isAmbientMuted;

        public bool isValid;
    }
}