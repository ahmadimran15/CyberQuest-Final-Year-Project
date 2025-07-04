using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableImage : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    private Vector3 originalPosition;
    private CanvasGroup canvasGroup;

    private GameObject draggingVisual; // The temp visual while dragging

    private void Awake()
    {
        image = GetComponent<Image>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Create a visual copy that follows the cursor
        draggingVisual = new GameObject("DraggingVisual");
        draggingVisual.transform.SetParent(transform.root);
        draggingVisual.transform.SetAsLastSibling();

        var img = draggingVisual.AddComponent<Image>();
        img.sprite = image.sprite;
        img.raycastTarget = false;
        img.SetNativeSize();

        var group = draggingVisual.AddComponent<CanvasGroup>();
        group.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (draggingVisual != null)
            draggingVisual.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Destroy the temp dragging visual
        if (draggingVisual != null)
            GameObject.Destroy(draggingVisual);
    }

   /* public void ResetToOriginal()
    {
        transform.position = originalPosition;
        gameObject.SetActive(true);
    }*/
}
