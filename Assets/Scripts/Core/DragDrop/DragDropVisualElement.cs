using System;
using UnityEngine.UIElements;

namespace CardsTable.DragDrop
{
    [UxmlElement("DragDropVisualElement")]
    public partial class DragDropVisualElement : VisualElement
    {
        [UxmlAttribute("drag-n-drop-enabled")]
        private bool dragDropEnabled;

        public bool IsDragDropEnabled => dragDropEnabled;

        private static readonly CustomStyleProperty<bool> dragDropEnabledProperty =
            new CustomStyleProperty<bool>("--drag-n-drop-enabled");


        public DragDropVisualElement()
        {
            RegisterCallback<AttachToPanelEvent>(OnAttachToPanel);
            RegisterCallback<CustomStyleResolvedEvent>(OnCustomStyleResolved);
        }

        private void OnCustomStyleResolved(CustomStyleResolvedEvent evt)
        {
            UnregisterCallback<CustomStyleResolvedEvent>(OnCustomStyleResolved);

            if (!evt.customStyle.TryGetValue(dragDropEnabledProperty, out dragDropEnabled))
                return;

            InavlidateDragDrop();
        }

        private void InavlidateDragDrop()
        {
            if (!dragDropEnabled)
                return;
                
            this.AddManipulator(new DragDropManipulator());
        }

        private void OnAttachToPanel(AttachToPanelEvent evt)
        {
            UnregisterCallback<AttachToPanelEvent>(OnAttachToPanel);

            InavlidateDragDrop();
        }
    }
}