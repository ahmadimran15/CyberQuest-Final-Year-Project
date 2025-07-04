using UnityEngine;
using UnityEngine.UI;

public class TileScript : MonoBehaviour
{
    public Image tileImage;

    public void SetImage(Sprite sprite)
    {
        tileImage.sprite = sprite;
    }

    public Sprite GetImage()
    {
        return tileImage.sprite;
    }

    public void OnClick()
    {
        int index = transform.GetSiblingIndex();  // Or use assigned index if more reliable in VR
        FindObjectOfType<PuzzleManager>().TryMoveTile(index);
    }
}
