using System;
using CardsTable.Player;

namespace CardsTable.UserState
{
    [Serializable]
    public struct UserStateData
    {
        public PlayerState playerState;
        public bool isSfxMuted;
        public bool isAmbientMuted;

        public bool isValid;
    }
}