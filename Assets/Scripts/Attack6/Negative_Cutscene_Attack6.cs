using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Negative_Cutscene_Attack6 : MonoBehaviour
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

        // Load the next scene (by name or build index)
        SceneManager.LoadScene("Level_Failed_Screen_Attack6"); // Replace with your scene name
        // OR
        //SceneManager.LoadScene(1); // You can use the build index instead
    }
}
