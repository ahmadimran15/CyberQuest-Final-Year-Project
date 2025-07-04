using UnityEngine;
using UnityEngine.SceneManagement;


public class SceenSwitch : MonoBehaviour
{
    
    public void LoadNextScene()
    {
        // This will load the scene with the specified name or build index
        SceneManager.LoadScene("GamePlay");  // Use scene name
                                 
    }


}
