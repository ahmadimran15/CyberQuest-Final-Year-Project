using UnityEngine;
using System.Collections;

public class NOCutsceneLevelPassed : MonoBehaviour
{
    public GameObject currentPanel; // e.g., Cutscene3Panel
    public GameObject nextPanel;    // e.g., CafeSceneAttack2and3Panel

    void Start()
    {
        StartCoroutine(SwitchPanelAfterDelay());
    }

    IEnumerator SwitchPanelAfterDelay()
    {
        yield return new WaitForSecondsRealtime(11f);

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


public class NOCutsceneLevelPassed : MonoBehaviour
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
        yield return new WaitForSecondsRealtime(11f);

        SceneManager.LoadScene("Level_Passed_Screen"); // Replace with your scene name

        // OR
        //SceneManager.LoadScene(1); // You can use the build index instead
    }
}

*/