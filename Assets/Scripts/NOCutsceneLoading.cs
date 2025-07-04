using UnityEngine;
using System.Collections;

public class NOCutsceneLoading : MonoBehaviour
{
    [Header("Panel References")]
    public GameObject currentPanel;  // The panel that is currently active (this one)
    public GameObject noCutscenePanel;  // The panel to display after waiting

    private void Start()
    {
        StartCoroutine(WaitAndSwitchPanel());
    }

    private IEnumerator WaitAndSwitchPanel()
    {
        yield return new WaitForSeconds(10f); // Wait for 10 seconds

        // Switch panels
        if (noCutscenePanel != null)
        {
            noCutscenePanel.SetActive(true);
            Debug.Log("NoCutscene panel activated.");
        }
        else
        {
            Debug.LogError("noCutscenePanel is NOT assigned in the Inspector!");
        }

        if (currentPanel != null)
        {
            currentPanel.SetActive(false);
            Debug.Log("Current panel deactivated.");
        }
    }
}


/*using UnityEngine;
using UnityEngine.SceneManagement;

public class NOCutsceneLoading : MonoBehaviour
{
    private void Start()
    {
        // Start a coroutine to wait for 10 seconds
        StartCoroutine(WaitAndLoadScene());
    }

    private System.Collections.IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(10f); // Wait for 10 seconds

        // Load your target scene after 10 seconds
        SceneManager.LoadScene("NOCutscene"); // Replace with your correct scene name
    }
}
*/