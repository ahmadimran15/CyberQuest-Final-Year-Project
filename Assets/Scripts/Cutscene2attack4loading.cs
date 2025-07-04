using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene2attack4loading : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Camera") // Detect Main Camera entering
        {
            if (CutSceneFlags.FreeWifiClicked)
            {
                SceneManager.LoadScene("Cutscene2attack4");
            }
            
        }
    }
}
