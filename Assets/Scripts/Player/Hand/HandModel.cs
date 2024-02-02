using System;
using System.Collections.Generic;
using CardsTable.PlayingCard;
using CardsTable.Settings;

namespace CardsTable.Player.Hand
{
    public class HandModel
    {
        private readonly HandSettings handSettings;
        private readonly List<CardData> cards = new ();

        public readonly Dictionary<CardData, CardModel> cardModels = new();

        private bool isActiveHand;
        public bool IsActiveHand
        {
            get => isActiveHand;
            set
            {
                if (isActiveHand == value)
                    return;

                isActiveHand = value;
                OnActiveHandCahnge(value);
            }
        }

        public bool HasStartCardsCount=> handSettings.StartCardsCount == cards.Count;

        public event Action<CardData> OnCardAdded = delegate {  };
        public event Action<CardData> OnCardRemoved = delegate {  };
        public event Action<bool> OnActiveHandCahnge = delegate {  };

        public HandModel(HandSettings handSettings)
        {
            this.handSettings = handSettings;
        }

        public void AddCard(CardData card)
        {
            cards.Add(card);

            OnCardAdded(card);
        }

        public void RemoveCard(CardData card)
        {
            cards.Remove(card);

            OnCardRemoved(card);
        }
    }
}
