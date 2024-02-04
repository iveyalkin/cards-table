using CardsTable.Core.DragDrop;
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
                currentCardPosition = target.transform.position,
                pickingMode = target.pickingMode,
                localPickOffset = evt.position,//evt.localPosition,
                isValid = true
            };

            target.pickingMode = PickingMode.Ignore;
            target.CapturePointer(evt.pointerId);

            evt.StopPropagation();

            SendPickEvent(target);
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
            if (hasRecever)
                SendDropEvent(receiver, target);

            SendDropEvent(target, receiver);
            Reset(evt, hasRecever);

            evt.StopPropagation();
        }

        private void Reset(PointerUpEvent evt, bool hasRecever)
        {
            if (!hasRecever)
                target.transform.position = currentDrag.currentCardPosition;

            target.ReleasePointer(evt.pointerId);
            target.pickingMode = currentDrag.pickingMode;

            currentDrag = default;
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

        private void SendPickEvent(VisualElement receiver)
        {
            var evt = DragPickEvent.GetPooled(receiver);

            // send the event one tick later
            receiver.schedule.Execute(() => {
                receiver.SendEvent(evt);
                evt.Dispose();
            });
        }
        
        private void SendDropEvent(VisualElement receiver, VisualElement subject)
        {
            var evt = DragDropEvent.GetPooled(this, target: receiver, subject: subject);

            // send the event one tick later
            receiver.schedule.Execute(() => {
                receiver.SendEvent(evt);
                evt.Dispose();
            });
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