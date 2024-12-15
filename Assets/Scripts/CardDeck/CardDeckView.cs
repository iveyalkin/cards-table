using System;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer.Unity;

namespace CardsTable.CardDeck
{
    public class CardDeckView : IInitializable, IDisposable
    {
        private readonly UIDocument uiDocument;

        private Button drawButton;

        public event Action OnDrawClick = delegate { };

        public CardDeckView(UIDocument uiDocument)
        {
            this.uiDocument = uiDocument;
        }

        void IInitializable.Initialize()
        {
            drawButton = uiDocument.rootVisualElement.Q<Button>("draw");
            
            drawButton.RegisterCallback<ClickEvent>(OnDeckClick);
        }

        void IDisposable.Dispose()
        {
            drawButton.UnregisterCallback<ClickEvent>(OnDeckClick);
        }

        private void OnDeckClick(ClickEvent evt)
        {
            Debug.Log("OnDeckClick");

            OnDrawClick();
        }
    }
}