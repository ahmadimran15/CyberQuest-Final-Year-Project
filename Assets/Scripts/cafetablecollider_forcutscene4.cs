using UnityEngine;

public class cafetablecollider_forcutscene4 : MonoBehaviour
{
    public GameObject cutscenePanel; // assign the cutscene GameObject to activate

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TriggerTable"))
        {
            Debug.Log("Main Camera entered TriggerTable zone");

            if (cutscenePanel != null)
                cutscenePanel.SetActive(true);
            else
                Debug.LogError("cutscenePanel not assigned in inspector!");
        }
    }
}


/*using UnityEngine;
using UnityEngine.SceneManagement;


public class cafetablecollider_forcutscene4 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Camera") // Detect Main Camera entering
        {

            SceneManager.LoadScene("Cutscene4"); // Load the cutscene
        }
    }
}
*/

/*using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Required for IEnumerator

public class cafetablecollider_forcutscene4 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Camera") // Detect Main Camera entering
        {
            StartCoroutine(LoadSceneAfterDelay());
        }
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(2f); // Wait for 2 seconds
        SceneManager.LoadScene("Cutscene4"); // Load the cutscene after the delay
    }
}*/
