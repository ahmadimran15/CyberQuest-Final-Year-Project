using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Attack4cutscene4aftervideo : MonoBehaviour
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
        yield return new WaitForSecondsRealtime(20f);

        // Load the next scene (by name or build index)
        CutSceneFlags.ExitCafeClicked = false;
        CutSceneFlags.PasswordWifiClicked = false;
        CutSceneFlags.FreeWifiClicked = false;
        CutSceneFlags.Image1Seen = false;
        CutSceneFlags.Image2Seen = false;
        CutSceneFlags.Image3Seen = false;
        CutSceneFlags.Image4Seen = false;

    SceneManager.LoadScene("Attack4_Level_Failed_Screen");
        
        // Replace with your scene name
        // OR
        //SceneManager.LoadScene(1); // You can use the build index instead
    }
}
