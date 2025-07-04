using UnityEngine;

public class LibrarySetup : MonoBehaviour
{
    private Collider bookShelfCollider;
    private Collider doorCollider;

    void Start()
    {
        // Find Bookshelf
        GameObject bookShelf = GameObject.Find("Books cabinet 1 (3)");
        if (bookShelf != null)
        {
            bookShelfCollider = bookShelf.GetComponent<Collider>();
            if (bookShelfCollider != null)
            {
                bookShelfCollider.enabled = true;  
                bookShelfCollider.isTrigger = true;
                Debug.Log("Bookshelf Collider Enabled as Trigger.");
            }
        }
        else
        {
            Debug.LogError("Books cabinet 1 (3) NOT FOUND in DemoTesting2!");
        }

        // Find Door
        GameObject door = GameObject.Find("Door 3");
        if (door != null)
        {
            doorCollider = door.GetComponent<Collider>();
            if (doorCollider != null)
            {
                doorCollider.enabled = false; 
                Debug.Log("Door Collider Disabled at Start.");
            }
        }
        else
        {
            Debug.LogError("Door 3 NOT FOUND in DemoTesting2!");
        }
    }
}
