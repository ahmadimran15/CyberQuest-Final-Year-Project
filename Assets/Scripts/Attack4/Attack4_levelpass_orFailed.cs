using UnityEngine;
using UnityEngine.SceneManagement;

public class Attack4_levelpass_orFailed : MonoBehaviour
{
    public GameObject currentPanel;   // e.g., Fail Panel
    public GameObject libraryPanel;   // Target panel to show (e.g., Library Panel)

    public void RestartLevel()
    {
        SceneManager.LoadScene("CafeSceneAttack4");

        CutSceneFlags.ExitCafeClicked = false;
        CutSceneFlags.PasswordWifiClicked = false;
        CutSceneFlags.FreeWifiClicked = false;
        /*// Show the library panel instead of reloading the scene
        if (currentPanel != null) currentPanel.SetActive(false);
        if (libraryPanel != null) libraryPanel.SetActive(true);*/
    }

    public void ReturntoMainScreen()
    {
        SceneManager.LoadScene("DemoScenefailedtesting");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("testingAttack5");
    }

    public void RestartPuzzleAttack6()
    {
        SceneManager.LoadScene("LaptopScreen");

        /*// Show the library panel instead of reloading the scene
        if (currentPanel != null) currentPanel.SetActive(false);
        if (libraryPanel != null) libraryPanel.SetActive(true);*/
    }

    public void RestartLevelAttack6()
    {
        SceneManager.LoadScene("LaptopScreen");

        /*// Show the library panel instead of reloading the scene
        if (currentPanel != null) currentPanel.SetActive(false);
        if (libraryPanel != null) libraryPanel.SetActive(true);*/
    }
}
