using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Make sure this is at the top

public class CutScene2Loading : MonoBehaviour
{
    public GameObject currentPanel;   // Panel to hide (e.g., Choice Panel)
    public GameObject cutscenePanel;  // Panel shown if user selects "Yes"
    public TextMeshProUGUI taskText; // Drag and drop in Inspector

    public GameObject libraryPanel;   // Panel shown if user selects "No"

    public void LoadNextScene()
    {
        if (currentPanel != null) currentPanel.SetActive(false);
        if (cutscenePanel != null) cutscenePanel.SetActive(true);
        // OR if using scene loading instead of panels:
        // SceneManager.LoadScene("Cutscene2");
    }
   
  public void NoUnlock()
    {
        CutSceneFlags.noClicked = true;

        if (currentPanel != null) currentPanel.SetActive(false);
        if (cutscenePanel != null) cutscenePanel.SetActive(false);
        if (libraryPanel != null)
        {
            libraryPanel.SetActive(true);

            // Find the "book" GameObject inside libraryPanel
            Transform bookTransform = libraryPanel.transform.Find("Books cabinet 1 (4)");
            if (bookTransform != null)
            {
                BoxCollider box = bookTransform.GetComponent<BoxCollider>();
                if (box != null)
                {
                    box.enabled = false; // Disable only the collider
                }
                else
                {
                    Debug.LogWarning("Book GameObject found, but it has no BoxCollider component.");
                }
            }
            else
            {
                Debug.LogWarning("No child GameObject named 'book' found under libraryPanel.");
            }

            // 🔻 Update TaskText to "Explore library"
            Transform taskTextTransform = libraryPanel.transform.Find("TaskText");
            if (taskTextTransform != null)
            {
                TextMeshProUGUI taskText = taskTextTransform.GetComponent<TextMeshProUGUI>();
                if (taskText != null)
                {
                    taskText.text = "Explore library";
                }
                else
                {
                    Debug.LogWarning("TaskText GameObject found, but no TextMeshProUGUI component attached.");
                }
            }
            else
            {
                Debug.LogWarning("No child GameObject named 'TaskText' found under libraryPanel.");
            }
        }

        // Optional: Scene loading alternative
        // SceneManager.LoadScene("DemoTesting2");
    }

}


/*using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene2Loading : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene("Cutscene2");
    }

    public void NoUnlock()
    {
        CutSceneFlags.noClicked = true;  // tell system No was clicked
        SceneManager.LoadScene("DemoTesting2");
    }
}
*/