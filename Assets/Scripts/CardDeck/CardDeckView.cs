using System;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer.Unity;

namespace CardsTable.CardDeck
{
    public class CardDeckView : IStartable, IDisposable
    {
        private readonly UIDocument uiDocument;

        private Button drawButton;

        public event Action OnDrawClick = delegate { };

        public CardDeckView(UIDocument uiDocument)
        {
            this.uiDocument = uiDocument;
        }

        void IStartable.Start()
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