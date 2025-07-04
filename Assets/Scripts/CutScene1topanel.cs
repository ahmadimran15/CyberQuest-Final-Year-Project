using UnityEngine;
using System.Collections;

public class CutScene1topanel : MonoBehaviour
{
    private Collider doorCollider;

    public GameObject nextPanel;       // Assign the next panel (e.g., Panel_to_cutscene2)
    public GameObject currentPanel;    // Assign the current cutscene panel (this one)

    void Start()
    {
        GameObject door = GameObject.Find("Door 3");

        if (door != null)
        {
            doorCollider = door.GetComponent<Collider>();
            if (doorCollider != null)
            {
                doorCollider.enabled = false; // Disable door collider initially
            }
        }
        else
        {
            Debug.LogError("Door 3 not found! Check the name in Hierarchy.");
        }

        StartCoroutine(SwitchPanelAfterDelay());
    }

    IEnumerator SwitchPanelAfterDelay()
    {
        yield return new WaitForSecondsRealtime(7f); // Adjust for your cutscene duration

        // Enable door collider
        if (doorCollider != null)
        {
            doorCollider.enabled = true;
        }

        // Switch panels
        if (currentPanel != null) currentPanel.SetActive(false);
        if (nextPanel != null) nextPanel.SetActive(true);
    }
}

/*using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CutScene1topanel : MonoBehaviour
{
    private Collider doorCollider; // Reference to the door collider

    void Start()
    {
        // Find "Door 3" GameObject in the scene
        GameObject door = GameObject.Find("Door 3");

        if (door != null)
        {
            doorCollider = door.GetComponent<Collider>();
            if (doorCollider != null)
            {
                doorCollider.enabled = false; // Disable door collider initially
            }
        }
        else
        {
            Debug.LogError("Door 3 not found! Check the name in Hierarchy.");
        }

        StartCoroutine(SwitchSceneAfterDelay());
    }

    IEnumerator SwitchSceneAfterDelay()
    {
        // Wait for 14 seconds (cutscene duration)
        yield return new WaitForSecondsRealtime(7f);

        // Enable door collider before switching scene
        if (doorCollider != null)
        {
            doorCollider.enabled = true;
        }

        // Load the next scene
        SceneManager.LoadScene("Panel_to_cutscene2");
    }
}
*/