using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene3attack4loading : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Camera") // Detect Main Camera entering
        {
            SceneManager.LoadScene("Cutscene3attack4"); // Load the cutscene
        }
    }

}
