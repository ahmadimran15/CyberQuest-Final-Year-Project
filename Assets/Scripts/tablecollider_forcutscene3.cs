using UnityEngine;

public class tablecollider_forcutscene3 : MonoBehaviour
{
    [Header("Panel References")]
    public GameObject currentPanel;     // Panel to hide
    public GameObject cutscenePanel;    // Panel to show (acts as Cutscene3)

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Camera")
        {
            if (cutscenePanel != null)
            {
                cutscenePanel.SetActive(true); // Show cutscene panel
                Debug.Log("Cutscene panel activated.");
            }
            else
            {
                Debug.LogError("Cutscene panel not assigned in inspector.");
            }

            if (currentPanel != null)
            {
                currentPanel.SetActive(false); // Hide current gameplay panel
                Debug.Log("Current panel deactivated.");
            }
        }
    }
}

/*using UnityEngine;
using UnityEngine.SceneManagement;

public class tablecollider_forcutscene3 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Camera") // Detect Main Camera entering
        {
            SceneManager.LoadScene("Cutscene3"); // Load the cutscene
        }
    }
}
*/