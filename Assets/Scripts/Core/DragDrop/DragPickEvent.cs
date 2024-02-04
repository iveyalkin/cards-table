using UnityEngine.UIElements;

namespace CardsTable.Core.DragDrop
{
    public class DragPickEvent : EventBase<DragPickEvent>
    {
        public DragPickEvent()
        {
            bubbles = true;
            tricklesDown = false;
        }

        protected override void Init()
        {
            base.Init();

            bubbles = true;
            tricklesDown = false;
        }

        public static DragPickEvent GetPooled(VisualElement target)
        {
            var evt = GetPooled();
            evt.target = target;

            return evt;
        }
    }
}