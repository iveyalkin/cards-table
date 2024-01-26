using System;
using UnityEngine.SceneManagement;

namespace CardsTable.Gameplay.Mode
{
    public class GameplayModeLoader
    {
        public event Action OnGameplayModeUnloaded = delegate { };

        public void LoadGameplayMode(GameplayMode gameMode)
        {
            SceneManager.LoadScene("Table", LoadSceneMode.Additive);
        }

        public void RestartGameplayMode()
        {
            SceneManager.UnloadSceneAsync("Table");
            SceneManager.LoadScene("Table", LoadSceneMode.Additive);
        }

        public void UnloadGameplayMode()
        {
            SceneManager.UnloadSceneAsync("Table");

            OnGameplayModeUnloaded();
        }
    }
}