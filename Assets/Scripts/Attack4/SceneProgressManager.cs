using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneProgressManager : MonoBehaviour
{
    private bool hasStartedLoading = false;

    void Update()
    {
        if (!hasStartedLoading &&
            CutSceneFlags.Image1Seen &&
            CutSceneFlags.Image2Seen &&
            CutSceneFlags.Image3Seen &&
            CutSceneFlags.Image4Seen)
        {
            Debug.Log("🎉 All tablets viewed. Loading next scene in 3 seconds...");
            StartCoroutine(LoadSceneAfterDelay("AttckerCrackingPasswordattack4newChecking", 3f));
            hasStartedLoading = true;
        }
    }

    IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
