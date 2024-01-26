using UnityEngine.UIElements;
using VContainer.Unity;

namespace CardsTable.UI.MainMenu
{
    public class MainMenuController : IInitializable
    {
        private readonly UIDocument document;

        public MainMenuController(UIDocument document)
        {
            this.document = document;
        }

        void IInitializable.Initialize()
        {
            document.rootVisualElement.Q<Button>("choose-game-mode").clicked += () =>
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Table", UnityEngine.SceneManagement.LoadSceneMode.Additive);
            };
        }
    }
}