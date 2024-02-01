using UnityEngine;
using UnityEngine.UIElements;

namespace CardsTable.DragDrop
{
    public class DragDropManipulator : PointerManipulator
    {
        private static readonly CustomStyleProperty<bool> dragDropEnabledProperty =
            new CustomStyleProperty<bool>("--drag-n-drop-enabled");

        private readonly ManipulatorActivationFilter activator = new();

        private DragState currentDrag;

        protected override void RegisterCallbacksOnTarget()
        {
            if (target is DragDropVisualElement dragDropVisualElement)
                InvalidateDragDrop(dragDropVisualElement.IsDragDropEnabled);

            target.RegisterCallback<PointerDownEvent>(OnPointerDown);
            target.RegisterCallback<PointerMoveEvent>(OnPointerMove);
            target.RegisterCallback<PointerUpEvent>(OnPointerUp);
            target.RegisterCallback<CustomStyleResolvedEvent>(OnCustomStyleResolved);
        }

        protected override void UnregisterCallbacksFromTarget()
        {
            target.UnregisterCallback<PointerDownEvent>(OnPointerDown);
            target.UnregisterCallback<PointerMoveEvent>(OnPointerMove);
            target.UnregisterCallback<PointerUpEvent>(OnPointerUp);
            target.UnregisterCallback<CustomStyleResolvedEvent>(OnCustomStyleResolved);
        }

        private void OnCustomStyleResolved(CustomStyleResolvedEvent evt)
        {
            var draggableEnabled = target is DragDropVisualElement dragDropVisualElement
                && dragDropVisualElement.IsDragDropEnabled;

            if (evt.customStyle.TryGetValue(dragDropEnabledProperty, out var value))
            {
                draggableEnabled = draggableEnabled || value;
            }

            InvalidateDragDrop(draggableEnabled);
        }

        private void InvalidateDragDrop(bool shouldEnable)
        {
            activators.Clear();

            if (shouldEnable)
                activators.Add(activator);
        }

        private void OnPointerDown(PointerDownEvent evt)
        {
            if (!CanStartManipulation(evt))
                return;

            currentDrag = new DragState
            {
                pickingMode = target.pickingMode,
                localPickOffset = evt.localPosition,
                isValid = true
            };

            target.pickingMode = PickingMode.Ignore;
            target.CapturePointer(evt.pointerId);

            evt.StopPropagation();
        }

        private void OnPointerMove(PointerMoveEvent evt)
        {
            if (!target.HasPointerCapture(evt.pointerId))
                return;

            if (!currentDrag.isValid)
            {
                target.ReleasePointer(evt.pointerId);
                return;
            }

            target.transform.position = (Vector3)((Vector2)evt.position - currentDrag.localPickOffset);

            evt.StopPropagation();
        }

        private void OnPointerUp(PointerUpEvent evt)
        {
            if (!target.HasPointerCapture(evt.pointerId))
                return;

            if (!currentDrag.isValid)
            {
                target.ReleasePointer(evt.pointerId);
                return;
            }

            var hasRecever = HasReceiver(evt.position, out var receiver);

            currentDrag = default;

            target.pickingMode = currentDrag.pickingMode;
            target.ReleasePointer(evt.pointerId);

            if (hasRecever)
                Send(receiver);

            evt.StopPropagation();
        }

        private bool HasReceiver(Vector2 position, out VisualElement receiver)
        {
            receiver = target.panel.Pick(position);
            var element = receiver;

            // walk up parent elements to see if any are receivers
            // while (element != null && !element.ClassListContains(dragDropRecieverClass))
            // element = element.parent;

            if (element != null)
            {
                receiver = element;
                return true;
            }

            return false;
        }

        private void Send(VisualElement receiver)
        {
            var evt = DragDropEvent.GetPooled(this, target);
            evt.target = receiver;

            // send the event one tick later
            receiver.schedule.Execute(() => receiver.SendEvent(evt));
        }

        private struct DragState
        {
            public PickingMode pickingMode;
            public Vector2 localPickOffset;
            public Vector2 currentCardPosition;
            public bool isValid;
        }
    }
}