using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class ChairCollideCutscene1 : MonoBehaviour
{
    public GameObject environment;     // The environment to hide
    public GameObject cutsceneObject;  // The object that plays the cutscene
    //public GameObject eventPanel;      // The UI panel shown after cutscene
    //public GameObject choicePanel;

    public GameObject xrOrigin;          // Reference to XR Origin (XR Rig)
    private CharacterController xrController;

   //public Transform xrTargetPosition;  // Drag XRTargetAfterCutscene here in the Inspector



    private void Start()
    {
        // Try getting CharacterController or any custom movement component
        if (xrOrigin != null)
        {
            xrController = xrOrigin.GetComponent<CharacterController>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger entered by: " + other );
        Debug.Log("Trigger entered by: " + other.name);

        if (other.CompareTag("Player"))
        {
            // Disable XR Rig movement/controller (if found)
            if (xrController != null)
                xrController.enabled = false;

            PlayNewCutscene();


            // Disable collider so it doesn't trigger again
            GetComponent<Collider>().enabled = false;


            //StartCoroutine(HandleCutscene());
        }
    }

    void PlayNewCutscene()
    {
        cutsceneObject.SetActive(true);
        environment.SetActive(false);
        //eventPanel.SetActive(false);
        

        // Hide UI until cutscene ends
       // eventPanel.SetActive(false);
       // choicePanel?.SetActive(false);                     // Hide any text

        Invoke("EndCutscene", 32f);               // Wait 4 seconds then end cutscene
    }
    void EndCutscene()
    {
        

        //  Move XR Rig to target position
       /* if (xrOrigin != null && xrTargetPosition != null)
        {
            xrOrigin.transform.position = xrTargetPosition.position;
            xrOrigin.transform.rotation = xrTargetPosition.rotation;
        }*/
        // Show notification
        if (xrController != null)
            xrController.enabled = true;  // Re-enable movement after cutscene

        cutsceneObject.SetActive(false);
        SceneManager.LoadScene("Level_Failed_ScreenAttack5");

        //eventPanel.SetActive(true);
        //choicePanel.SetActive(true);
    }

  
}
