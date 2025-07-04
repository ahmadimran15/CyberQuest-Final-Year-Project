using UnityEngine;
using System.Collections;

public class Cutscene4_1loading : MonoBehaviour
{
    public GameObject currentPanel; // e.g., CutScene4Panel
    public GameObject nextPanel;    // e.g., AttackerCrackingPasswordPanel

    void Start()
    {
        StartCoroutine(SwitchPanelAfterDelay());
    }

    IEnumerator SwitchPanelAfterDelay()
    {
        yield return new WaitForSecondsRealtime(12f);

        if (currentPanel != null)
            currentPanel.SetActive(false);

        if (nextPanel != null)
            nextPanel.SetActive(true);
    }
}

/*
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Cutscene4_1loading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SwitchSceneAfterDelay());
    }

    // Coroutine that waits for 30 seconds in real-time and then switches the scene
    IEnumerator SwitchSceneAfterDelay()
    {
        // Wait for 30 seconds (real-time, not affected by timeScale)
        yield return new WaitForSecondsRealtime(12f);

        // Load the next scene (by name or build index)
        SceneManager.LoadScene("Cutscene5"); // Replace with your scene name
        // OR
        //SceneManager.LoadScene(1); // You can use the build index instead
    }
}
*/
