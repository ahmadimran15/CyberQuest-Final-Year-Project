using UnityEngine;

public class cafetablecollidernew : MonoBehaviour
{
    public GameObject cutscenePanel; // Assign in inspector
    public GameObject currentPanel; // Optional: disable the table panel

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name);

        if (other.gameObject.name == "Main Camera")
        {
            if (cutscenePanel != null)
            {
                cutscenePanel.SetActive(true);
                Debug.Log("Cutscene panel activated.");
            }
            else
            {
                Debug.LogError("cutscenePanel is NOT assigned in Inspector!");
            }

            if (currentPanel != null)
            {
                currentPanel.SetActive(false);
                Debug.Log("Current panel deactivated.");
            }
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
