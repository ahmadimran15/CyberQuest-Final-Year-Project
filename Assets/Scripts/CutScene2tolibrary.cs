using UnityEngine;
using TMPro;
using System.Collections;

public class CutScene2tolibrary : MonoBehaviour
{
    private Collider doorCollider;
    private Collider bookShelfCollider;
    private TextMeshProUGUI taskText;
    private Transform mainCamera;

    public GameObject currentPanel;  // This panel (e.g., Cutscene2)
    public GameObject nextPanel;     // The Library panel

    void Start()
    {
        mainCamera = Camera.main.transform;

        // Find and update TaskText
        GameObject taskObject = GameObject.Find("TaskText");
        if (taskObject != null)
        {
            taskText = taskObject.GetComponent<TextMeshProUGUI>();
            taskText.text = "Go to the Bookshelf.";
        }
        else
        {
            Debug.LogError("TaskText not found! Check Hierarchy.");
        }

        StartCoroutine(SwitchPanelAfterDelay());
    }

    IEnumerator SwitchPanelAfterDelay()
    {
        yield return new WaitForSecondsRealtime(11f);

        // Set Camera position and rotation
        if (mainCamera != null)
        {
            mainCamera.position = new Vector3(10f, 1.5f, 5f);
            mainCamera.rotation = Quaternion.Euler(0f, 0f, 0f);
            mainCamera.localScale = Vector3.one;
        }

        // Enable Bookshelf
        GameObject bookShelf = GameObject.Find("Books cabinet 1 (3)");
        if (bookShelf != null)
        {
            bookShelfCollider = bookShelf.GetComponent<Collider>();
            if (bookShelfCollider != null)
            {
                bookShelfCollider.enabled = true;
                bookShelfCollider.isTrigger = false;
            }
        }

        // Enable Door
        GameObject door = GameObject.Find("Door 3");
        if (door != null)
        {
            doorCollider = door.GetComponent<Collider>();
            if (doorCollider != null)
                doorCollider.enabled = true;
        }

        // Update task text
        GameObject taskObj = GameObject.Find("TaskText");
        if (taskObj != null)
        {
            taskText = taskObj.GetComponent<TextMeshProUGUI>();
            taskText.text = "Exit the Library and go to the cafe.";
        }

        // Disable LibraryManager if found
        GameObject libraryManager = GameObject.Find("LibraryManager");
        if (libraryManager != null)
        {
            libraryManager.SetActive(false);
        }

        // Switch panels
        if (currentPanel != null) currentPanel.SetActive(false);
        if (nextPanel != null) nextPanel.SetActive(true);
    }
}

/*using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class CutScene2tolibrary : MonoBehaviour
{
    private Collider doorCollider;
    private Collider bookShelfCollider;
    private TextMeshProUGUI taskText;
    private Transform mainCamera;

    void Start()
    {
        mainCamera = Camera.main.transform; // Get Main Camera

        // Find TaskText
        GameObject taskObject = GameObject.Find("TaskText");
        if (taskObject != null)
        {
            taskText = taskObject.GetComponent<TextMeshProUGUI>();
            taskText.text = "Go to the Bookshelf."; // Initial task
        }
        else
        {
            Debug.LogError("TaskText not found! Check Hierarchy.");
        }

        StartCoroutine(SwitchSceneAfterDelay());
    }

    IEnumerator SwitchSceneAfterDelay()
    {
        yield return new WaitForSecondsRealtime(11f);

        Debug.Log("Cutscene finished. Loading DemoTesting2...");

        SceneManager.sceneLoaded += OnSceneLoaded; // Attach event
        SceneManager.LoadScene("DemoTesting2");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "DemoTesting2")
        {
            // Set Camera position & rotation
            Camera mainCam = Camera.main;
            if (mainCam != null)
            {
                mainCam.transform.position = new Vector3(10f, 1.5f, 5f);
                mainCam.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                mainCam.transform.localScale = Vector3.one;
                Debug.Log("Camera position and rotation set.");
            }

            // Find Bookshelf
            GameObject bookShelf = GameObject.Find("Books cabinet 1 (3)");
            if (bookShelf != null)
            {
                bookShelfCollider = bookShelf.GetComponent<Collider>();
                if (bookShelfCollider != null)
                {
                    bookShelfCollider.enabled = true; // Enable Bookshelf
                    bookShelfCollider.isTrigger = false; // Ensure it's not a trigger
                    Debug.Log("Bookshelf Collider Disabled.");
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
                    doorCollider.enabled = true; // Enable Door Collider
                    Debug.Log("Door Collider Enabled.");
                }
            }
            else
            {
                Debug.LogError("Door 3 NOT FOUND in DemoTesting2!");
            }

            // Find Task Text Again in the New Scene
            GameObject taskObject = GameObject.Find("TaskText");
            if (taskObject != null)
            {
                taskText = taskObject.GetComponent<TextMeshProUGUI>();
                taskText.text = "Exit the Library and go to the cafe.";
            }
            else
            {
                Debug.LogError("TaskText NOT FOUND in DemoTesting2!");
            }

            // *Disable LibraryManager*
            GameObject libraryManager = GameObject.Find("LibraryManager");
            if (libraryManager != null)
            {
                libraryManager.SetActive(false); // *Disable it*
                Debug.Log("LibraryManager Disabled.");
            }
            else
            {
                Debug.LogError("LibraryManager NOT FOUND in DemoTesting2!");
            }

            SceneManager.sceneLoaded -= OnSceneLoaded; // Remove event listener
        }
    }
}*/