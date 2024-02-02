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
        private VisualElement cover;

        private DragState currentDrag;

        public event Action OnDragStart = delegate { };
        public event Action OnDragStop = delegate { };
        public event Action OnDragUpdate = delegate { };

        // todo: figure out the difference and the best source of the position
        private Vector2 Position
        {
            get
            {
                return uiDocument.rootVisualElement.transform.position;
                
                // var worldBound = uiDocument.rootVisualElement.worldBound;
                // return new Vector2(worldBound.x, worldBound.y);
            }
            set
            {
                if (currentDrag.isValid)
                {
                    currentDrag.currentCardPosition = value;
                }

                uiDocument.rootVisualElement.transform.position = value;
                
                // var style = uiDocument.rootVisualElement.style;
                // style.left = position.x;
                // style.top = position.y;
            }
        }

        public CardView(UIDocument uiDocument)
        {
            this.uiDocument = uiDocument;
        }

        void IStartable.Start()
        {
            rankLabel = uiDocument.rootVisualElement.Q<Label>("rank");
            suitImage = uiDocument.rootVisualElement.Q<VisualElement>("suit");
            colorBackground = uiDocument.rootVisualElement.Q<VisualElement>("color");
            cover = uiDocument.rootVisualElement.Q<VisualElement>("cover");

            SetupDragAndDrop(uiDocument.rootVisualElement);
        }

        void IDisposable.Dispose()
        {
            ReleaseDragAndDrop(uiDocument.rootVisualElement);
        }

        private void ReleaseDragAndDrop(VisualElement card)
        {
            // aid editor workflow
            if (card == null)
            {
                return;
            }

            card.UnregisterCallback<PointerDownEvent>(OnPointerDown);
            card.UnregisterCallback<PointerMoveEvent>(OnPointerMove);
            card.UnregisterCallback<PointerUpEvent>(OnPointerUp);
        }

        private void SetupDragAndDrop(VisualElement card)
        {
            uiDocument.rootVisualElement.style.position = UnityEngine.UIElements.Position.Absolute;

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

            currentDrag.originalPointerPosition = pointerPosition;

            SetPosition(currentDrag.currentCardPosition + delta);

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
                currentCardPosition = Position,
                isValid = true,
            };

            OnDragStart();
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

        private struct DragState
        {
            public Vector2 originalPointerPosition;
            public Vector2 currentCardPosition;
            public bool isValid;
        }
    }
}