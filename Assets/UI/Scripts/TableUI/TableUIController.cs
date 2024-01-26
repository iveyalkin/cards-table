using System;
using VContainer.Unity;

namespace CardsTable.UI.TableUI
{
    public class TableUIController : IInitializable, IDisposable
    {
        private readonly TableUIView view;

        public TableUIController(TableUIView view)
        {
            this.view = view;
        }

        void IInitializable.Initialize()
        {
            view.OnOpenPauseMenu += OpenPauseMenu;
            view.OnClosePauseMenu += ClosePauseMenu;
            view.OnRestartTable += RestartTable;
            view.OnQuitTable += QuitTable;
        }

        void IDisposable.Dispose()
        {
            view.OnOpenPauseMenu -= OpenPauseMenu;
            view.OnClosePauseMenu -= ClosePauseMenu;
            view.OnRestartTable -= RestartTable;
            view.OnQuitTable -= QuitTable;
        }

        private void OpenPauseMenu()
        {
            view.OpenPauseMenu();
        }

        private void ClosePauseMenu()
        {
           view.ClosePauseMenu();
        }

        private void RestartTable()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Table");
        }

        private void QuitTable()
        {
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("Table");
        }
    }
}
