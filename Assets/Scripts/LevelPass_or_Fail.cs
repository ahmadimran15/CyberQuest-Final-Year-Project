using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPass_or_Fail : MonoBehaviour
{
    public GameObject currentPanel;   // e.g., Fail Panel
    public GameObject libraryPanel;   // Target panel to show (e.g., Library Panel)

    public void RestartLevel()
    {
        /*// Show the library panel instead of reloading the scene
        if (currentPanel != null) currentPanel.SetActive(false);
        if (libraryPanel != null) libraryPanel.SetActive(true);*/

        SceneManager.LoadScene("Level1");

    }

    public void RestartLevelAttack5()
    {
        /*// Show the library panel instead of reloading the scene
        if (currentPanel != null) currentPanel.SetActive(false);
        if (libraryPanel != null) libraryPanel.SetActive(true);*/

        SceneManager.LoadScene("testingAttack5");

    }
    public void ReturntoMainScreen()
    {
        SceneManager.LoadScene("DemoScenefailedtesting");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("CafeSceneAttack4");
    }

    public void NextLevelAtatck5()
    {
        SceneManager.LoadScene("LaptopScreen");
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