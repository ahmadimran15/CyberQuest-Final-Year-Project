using UnityEngine;

public class ExitButtonHandler : MonoBehaviour
{
    public GameObject exitScreen;  // Drag your full screen panel here

    public void ShowExitScreen()
    {
        exitScreen.SetActive(true);  // This makes the exit screen visible
    }

    public void HideExitScreen()
    {
        exitScreen.SetActive(false);  // This makes the exit screen visible
    }

}
