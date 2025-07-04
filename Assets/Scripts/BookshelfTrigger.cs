using UnityEngine;

public class BookshelfTrigger : MonoBehaviour
{
    [Header("Panel References")]
    public GameObject currentPanel;     // Panel to hide
    public GameObject cutscenePanel;    // Panel to show (Cutscene1 equivalent)

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Camera")
        {
            if (cutscenePanel != null)
            {
                cutscenePanel.SetActive(true); // Show the cutscene panel
                Debug.Log("Cutscene panel activated.");
            }
            else
            {
                Debug.LogError("CutscenePanel not assigned!");
            }

            if (currentPanel != null)
            {
                currentPanel.SetActive(false); // Hide current panel
                Debug.Log("Current panel deactivated.");
            }
        }
    }
}

/*using UnityEngine;
using UnityEngine.SceneManagement;

public class BookshelfTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Camera") // Detect Main Camera entering
        {
            SceneManager.LoadScene("Cutscene1"); // Load the cutscene
        }
    }
}
*/