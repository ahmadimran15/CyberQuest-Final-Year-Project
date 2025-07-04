using UnityEngine;
using UnityEngine.UI;

public class DragManager : MonoBehaviour
{
    public static DragManager Instance;

    public Image dragIcon; // Assign in inspector
    private RectTransform dragIconTransform;

    private void Awake()
    {
        Instance = this;
        dragIconTransform = dragIcon.GetComponent<RectTransform>();
        dragIcon.gameObject.SetActive(false);
    }

    public void BeginDrag(Sprite sprite)
    {
        dragIcon.sprite = sprite;
        dragIcon.color = Color.white;
        dragIcon.gameObject.SetActive(true);
    }

    public void Drag(Vector2 position)
    {
        dragIconTransform.position = position;
    }

    public void EndDrag()
    {
        dragIcon.sprite = null;
        dragIcon.color = new Color(1, 1, 1, 0); // hide
        dragIcon.gameObject.SetActive(false);
    }
}
