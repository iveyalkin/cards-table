using CardsTable.PlayingCard;
using UnityEngine.UIElements;
using VContainer.Unity;

namespace CardsTable.UI.PlayingCard
{
    public class CardView : ICardView, IInitializable
    {
        private UIDocument uiDocument;

        private Label rankLabel;
        private VisualElement suitImage;
        private VisualElement colorBackground;

        public CardView(UIDocument uiDocument)
        {
            this.uiDocument = uiDocument;
        }

        void IInitializable.Initialize()
        {
            rankLabel = uiDocument.rootVisualElement.Q<Label>("rank");
            suitImage = uiDocument.rootVisualElement.Q<VisualElement>("suit");
            colorBackground = uiDocument.rootVisualElement.Q<VisualElement>("color-background");
        }

        public void Show(CardData state)
        {
            rankLabel.text = $"{state.rank}";
            suitImage.style.backgroundImage = new StyleBackground(state.suit);
            colorBackground.style.backgroundColor = state.color;
        }
    }
}