using UnityEngine;
using UnityEngine.SceneManagement;

public class Attack4wifihandling : MonoBehaviour
{
    public void FreeWifi()
    {
        CutSceneFlags.FreeWifiClicked = true;  // tell system FreeWifi was clicked
        SceneManager.LoadScene("CafeSceneAttack4");
    }
    public void secondWifi()
    {
        //CutSceneFlags.FreeWifiClicked = true;  // tell system FreeWifi was clicked
        //SceneManager.LoadScene("CutscenePasswordWifiattack4");
    }

    public void PasswordWifi()
    {
        //CutSceneFlags.noClicked = true;  // tell system No was clicked
        // SceneManager.LoadScene("FreeWifiAsking");

        CutSceneFlags.PasswordWifiClicked = true;
        SceneManager.LoadScene("CafeSceneAttack4");
        
    }
}
