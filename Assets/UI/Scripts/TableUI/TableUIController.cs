using System;
using  UnityEngine.SceneManagement;
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
            SceneManager.UnloadSceneAsync("Table");
            SceneManager.LoadScene("Table", LoadSceneMode.Additive);
        }

        private void QuitTable()
        {
            SceneManager.UnloadSceneAsync("Table");
        }
    }
}
