using System;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer.Unity;

namespace CardsTable.PlayingCard
{
    public class CardView : ICardView, IStartable, IDisposable
    {
        private UIDocument uiDocument;

        private Label rankLabel;
        private VisualElement suitImage;
        private VisualElement colorBackground;

        private DragState currentDrag;

        public event Action OnDragStart = delegate { };
        public event Action OnDragStop = delegate { };
        public event Action OnDragUpdate = delegate { };

        public CardView(UIDocument uiDocument)
        {
            this.uiDocument = uiDocument;
        }

        void IStartable.Start()
        {
            rankLabel = uiDocument.rootVisualElement.Q<Label>("rank");
            suitImage = uiDocument.rootVisualElement.Q<VisualElement>("suit");
            colorBackground = uiDocument.rootVisualElement.Q<VisualElement>("color");

            SetupDragAndDrop(uiDocument.rootVisualElement);
        }

        void IDisposable.Dispose()
        {
            ReleaseDragAndDrop(uiDocument.rootVisualElement);
        }

        private void ReleaseDragAndDrop(VisualElement card)
        {
            card.UnregisterCallback<PointerDownEvent>(OnPointerDown);
            card.UnregisterCallback<PointerMoveEvent>(OnPointerMove);
            card.UnregisterCallback<PointerUpEvent>(OnPointerUp);
        }

        private void SetupDragAndDrop(VisualElement card)
        {
            uiDocument.rootVisualElement.style.position = Position.Absolute;

            card.RegisterCallback<PointerDownEvent>(OnPointerDown);
            card.RegisterCallback<PointerMoveEvent>(OnPointerMove);
            card.RegisterCallback<PointerUpEvent>(OnPointerUp);
        }

        private void OnPointerUp(PointerUpEvent evt)
        {
            // Debug.Log("OnPointerUp");

            currentDrag = new DragState();

            uiDocument.rootVisualElement.ReleasePointer(evt.pointerId);

            OnDragStop();
        }

        private void OnPointerMove(PointerMoveEvent evt)
        {
            // Debug.Log($"OnPointerMove");

            if (!currentDrag.isValid || !uiDocument.rootVisualElement.HasPointerCapture(evt.pointerId))
            {
                return;
            }

            var pointerPosition = (Vector2) evt.position;
            var delta = pointerPosition - currentDrag.originalPointerPosition;

            currentDrag.currentCardPosition += delta;
            currentDrag.originalPointerPosition = pointerPosition;

            MoveCard(currentDrag.currentCardPosition);

            OnDragUpdate();
        }

        private void OnPointerDown(PointerDownEvent evt)
        {
            // Debug.Log("OnPointerDown");

            var card = uiDocument.rootVisualElement;
            card.CapturePointer(evt.pointerId);
            card.BringToFront();

            currentDrag = new DragState {
                originalPointerPosition = evt.position,
                currentCardPosition = GetPosition(uiDocument.rootVisualElement.style),
                isValid = true,
            };

            OnDragStart();
        }

        public void Show(CardData state)
        {
            rankLabel.text = $"{state.rank}";
            suitImage.style.backgroundImage = new StyleBackground(state.suit);
            colorBackground.style.backgroundColor = state.color;
        }

        private void MoveCard(Vector2 position)
        {
            var style = uiDocument.rootVisualElement.style;
            style.left = position.x;
            style.top = position.y;
        }

        private Vector2 GetPosition(IStyle style)
        {
            return new Vector2(style.left.value.value, style.top.value.value);
        }

        private struct DragState
        {
            public Vector2 originalPointerPosition;
            public Vector2 currentCardPosition;
            public bool isValid;
        }
    }
}