using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPass_or_Fail_Attacker : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject libraryPanel;

    public void RestartLevel()
    {
        if (currentPanel != null) currentPanel.SetActive(false);
        if (libraryPanel != null) libraryPanel.SetActive(true);
    }

    public void ReturntoMainScreen()
    {
        SceneManager.LoadScene("DemoScenefailedtesting");
    }

    public void NextLevel()
    {
        // Register callback for scene loaded
        SceneManager.sceneLoaded += OnLevel1Loaded;
        SceneManager.LoadScene("Level1");
    }

    void OnLevel1Loaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level1")
        {
            // Turn off all root GameObjects
            foreach (GameObject obj in scene.GetRootGameObjects())
            {
                obj.SetActive(false);
            }

            // Try to find the AttackerScreenGameObject and enable it
            GameObject attackerScreen = GameObject.Find("AttckerCrackingPassword");
            if (attackerScreen != null)
            {
                attackerScreen.SetActive(true);
            }

            // Unsubscribe so it doesn't trigger on future loads
            SceneManager.sceneLoaded -= OnLevel1Loaded;
        }
    }
}



/*using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPass_or_Fail : MonoBehaviour
{
    *//*public void Exitgame()
    {
        Application.Exit();
    }
*//*
    public void RestartLevel()
    {
        CutSceneFlags.noClicked = false;  // tell system No was clicked
        SceneManager.LoadScene("DemoTesting2");
    }

    public void ReturntoMainScreen()
    {
        SceneManager.LoadScene("DemoScenefailedtesting"); // Replace with your scene name
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("CafeSceneAttack4"); // Replace with your scene name
    }

}
*/