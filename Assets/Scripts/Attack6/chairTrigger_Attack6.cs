using UnityEngine;
using UnityEngine.SceneManagement;

public class chairTrigger_Attack6 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Camera") // Detect Main Camera entering
        {
            SceneManager.LoadScene("SittingCutsceneAttack6"); // Load the cutscene
        }
    }
}

