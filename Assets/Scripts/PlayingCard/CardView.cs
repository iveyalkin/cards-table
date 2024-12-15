using System;
using CardsTable.Core.DragDrop;
using CardsTable.DragDrop;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer.Unity;

namespace CardsTable.PlayingCard
{
    public class CardView : ICardView, IInitializable, IDisposable
    {
        private UIDocument uiDocument;

        private Label rankLabel;
        private VisualElement suitImage;
        private VisualElement colorBackground;
        private VisualElement cover;

        public event Action OnPicked = delegate { };
        public event Action OnPlaced = delegate { };

        // todo: figure out the difference and the best source of the position
        private Vector2 Position
        {
            get
            {
                return uiDocument.rootVisualElement.transform.position;
            }
            set
            {
                uiDocument.rootVisualElement.transform.position = value;
            }
        }

        public CardView(UIDocument uiDocument)
        {
            this.uiDocument = uiDocument;
        }

        void IInitializable.Initialize()
        {
            rankLabel = uiDocument.rootVisualElement.Q<Label>("rank");
            suitImage = uiDocument.rootVisualElement.Q<VisualElement>("suit");
            colorBackground = uiDocument.rootVisualElement.Q<VisualElement>("color");
            cover = uiDocument.rootVisualElement.Q<VisualElement>("cover");

            uiDocument.rootVisualElement.RegisterCallback<DragDropEvent>(OnDrop);
            uiDocument.rootVisualElement.RegisterCallback<DragPickEvent>(OnPick);
        }

        void IDisposable.Dispose()
        {
            uiDocument.rootVisualElement.UnregisterCallback<DragDropEvent>(OnDrop);
            uiDocument.rootVisualElement.UnregisterCallback<DragPickEvent>(OnPick);
        }

        private void OnPick(DragPickEvent evt)
        {
            OnPicked();
            Debug.Log("Picked");
        }

        private void OnDrop(DragDropEvent evt)
        {
            OnPlaced();
            Debug.Log("Dropped");
        }

        public void Show(CardData state)
        {
            rankLabel.text = $"{state.rank}";
            suitImage.style.backgroundImage = new StyleBackground(state.suit);
            colorBackground.style.backgroundColor = state.color;

            FlipCard(state.isFaceUp);
        }

        public void FlipCard(bool shouldFaceUp)
        {
            cover.style.display = shouldFaceUp ? DisplayStyle.None : DisplayStyle.Flex;
        }

        public void SetPosition(Vector2 position) => Position = position;

        public void SetInteractable(bool isInteractable)
        {
            uiDocument.rootVisualElement.SetEnabled(isInteractable);
        }
    }
}