using UnityEngine;
using UnityEngine.UIElements;

namespace CardsTable.DragDrop
{
    [UxmlElement("DropReceiverVisualElement")]
    public partial class DropReceiverVisualElement : VisualElement
    {
        public DropReceiverVisualElement()
        {
            RegisterCallback<DragDropEvent>(OnDragDrop);
        }

        private void OnDragDrop(DragDropEvent evt)
        {
            Debug.Log($"Received {evt.subject}, tager {evt.target}");
        }
    }
}