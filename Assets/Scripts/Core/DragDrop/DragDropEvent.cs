using UnityEngine.UIElements;

namespace CardsTable.DragDrop
{
    public class DragDropEvent : EventBase<DragDropEvent>
    {
        public DragDropManipulator manipulator { get; protected set; }

        /// <summary>
        /// What is being dragged
        /// </summary>
        public VisualElement subject { get; protected set; }

        public DragDropEvent()
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

        public static DragDropEvent GetPooled(DragDropManipulator manipulator, VisualElement subject)
        {
            var evt = GetPooled();
            evt.manipulator = manipulator;
            evt.subject = subject;

            return evt;
        }
    }
}