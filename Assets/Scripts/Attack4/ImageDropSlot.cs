using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageDropSlot : MonoBehaviour, IDropHandler
{
    public Image buttonImage;

    public void OnDrop(PointerEventData eventData)
    {
        var draggedImage = eventData.pointerDrag?.GetComponent<DraggableImage>();
        if (draggedImage != null)
        {
            // Copy the sprite to the slot image instead of moving it
            buttonImage.sprite = draggedImage.image.sprite;
            buttonImage.color = Color.white; // Ensure visibility
        }
    }
}
