using UnityEngine;
using TMPro;

public class Cafeattack4Table3taskupdate : MonoBehaviour
{
    public AudioSource audioSource;

    [Header("Voice Clips for Cafe Task Updates")]
    public AudioClip clip_GoToTable3;         // For "Go to Table 3 and sit"
    public AudioClip clip_ExitCafe;           // For "Exit the Cafe"
    public AudioClip clip_Find4Tiles;         // For "Exit the Cafe"
    public AudioClip clip_pinLocation;


    public GameObject progressBarLow;

    private void PlayAudio(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    void Start()
    {
        PlayAudio(clip_pinLocation);

        //Only if No was clicked
        if (CutSceneFlags.FreeWifiClicked)
        {
            /*// Enable nocutscene script
            GameObject nocutsceneObj = GameObject.Find("nocutscene");
            if (nocutsceneObj != null)
            {
                nocutsceneObj.GetComponent<NOCutsceneLoading>().enabled = true;
                Debug.Log("NOCutsceneLoading script enabled.");
            }*/

            // Update Task Text
            GameObject taskObject = GameObject.Find("TaskText");
            if (taskObject != null)
            {
                var taskText = taskObject.GetComponent<TextMeshProUGUI>();
                taskText.text = "Go to Table 3 and sit";
                PlayAudio(clip_GoToTable3);
            }

            // 🔹 Deactivate Int_FFK_01_Floor_01 (23)
            GameObject floorObject = GameObject.Find("Int_FFK_01_Floor_01 (23)");
            if (floorObject != null)
            {
                floorObject.SetActive(false);
            }
            else
            {
                Debug.LogWarning("Int_FFK_01_Floor_01 (23) not found in scene.");
            }

            // 🔹 Deactivate Progress bar 
            GameObject Progress_barObject = GameObject.Find("progressbar");
            if (Progress_barObject != null)
            {
                Progress_barObject.SetActive(false);
            }
            else
            {
                Debug.LogWarning("Progress Bar not found in scene.");
            }

            if (progressBarLow != null)
            {
                progressBarLow.SetActive(true);
            }



            /*  // Optional: Disable LibraryManager
              GameObject libraryManager = GameObject.Find("LibraryManager");
              if (libraryManager != null)
              {
                  libraryManager.SetActive(false);
                  Debug.Log("LibraryManager Disabled.");
              }*/

            // Reset flag if you want it to only trigger once
            // CutSceneFlags.noClicked = false;   // Optional


        }

        if (CutSceneFlags.ExitCafeClicked)
        {
            // Update Task Text
            GameObject taskObject = GameObject.Find("TaskText");
            if (taskObject != null)
            {
                var taskText = taskObject.GetComponent<TextMeshProUGUI>();
                taskText.text = "Exit the Cafe";
                PlayAudio(clip_ExitCafe);
            }

            // 🔹 Deactivate Int_FFK_01_Floor_01 (23)
            GameObject floorObject = GameObject.Find("Int_FFK_01_Floor_01 (23)");
            if (floorObject != null)
            {
                floorObject.SetActive(false);
            }
            else
            {
                Debug.LogWarning("Int_FFK_01_Floor_01 (23) not found in scene.");
            }


            // 🔹 Disable BoxCollider on Door
            GameObject doorObject2 = GameObject.Find("ExtInt_FFK_Door_01_01.001");
            if (doorObject2 != null)
            {
                BoxCollider collider2 = doorObject2.GetComponent<BoxCollider>();
                if (collider2 != null)
                {
                    collider2.enabled = true;
                }
                else
                {
                    Debug.LogWarning("No BoxCollider found on FFK_Table_01_01 (2)");
                }
            }
            else
            {
                Debug.LogWarning("FFK_Table_01_01 (2) not found in scene.");
            }

            // 🔹 Disable BoxCollider on FFK_Chair_02_01
            GameObject stoolObject = GameObject.Find("FFK_Chair_02_01");
            if (stoolObject != null)
            {
                BoxCollider collider = stoolObject.GetComponent<BoxCollider>();
                if (collider != null)
                {
                    collider.enabled = false;
                }
                else
                {
                    Debug.LogWarning("No BoxCollider found on FFK_Chair_02_01");
                }
            }
            else
            {
                Debug.LogWarning("FFK_Chair_02_01 not found in scene.");
            }

            // 🔹 Disable BoxCollider on FFK_Table_01_01 (2)
            GameObject tableObject = GameObject.Find("FFK_Table_01_01 (2)");
            if (tableObject != null)
            {
                BoxCollider collider = tableObject.GetComponent<BoxCollider>();
                if (collider != null)
                {
                    collider.enabled = false;
                }
                else
                {
                    Debug.LogWarning("No BoxCollider found on FFK_Table_01_01 (2)");
                }
            }
            else
            {
                Debug.LogWarning("FFK_Table_01_01 (2) not found in scene.");
            }

            

        }

        if (CutSceneFlags.PasswordWifiClicked)
        {
            // 🔹 Update Task Text
            GameObject taskObject = GameObject.Find("TaskText");
            if (taskObject != null)
            {
                var taskText = taskObject.GetComponent<TextMeshProUGUI>();
                if (taskText != null)
                {
                    taskText.text = "Find the 4 tiles in the cafe";
                    PlayAudio(clip_Find4Tiles);
                }
            }



            // 🔹 Disable BoxCollider on FFK_Chair_02_01
            GameObject stoolObject = GameObject.Find("FFK_Chair_02_01");
            if (stoolObject != null)
            {
                BoxCollider collider = stoolObject.GetComponent<BoxCollider>();
                if (collider != null)
                {
                    collider.enabled = false;
                }
                else
                {
                    Debug.LogWarning("No BoxCollider found on FFK_Chair_02_01");
                }
            }
            else
            {
                Debug.LogWarning("FFK_Chair_02_01 not found in scene.");
            }

            // 🔹 Disable BoxCollider on FFK_Table_01_01 (2)
            GameObject tableObject = GameObject.Find("FFK_Table_01_01 (2)");
            if (tableObject != null)
            {
                BoxCollider collider = tableObject.GetComponent<BoxCollider>();
                if (collider != null)
                {
                    collider.enabled = false;
                }
                else
                {
                    Debug.LogWarning("No BoxCollider found on FFK_Table_01_01 (2)");
                }
            }
            else
            {
                Debug.LogWarning("FFK_Table_01_01 (2) not found in scene.");
            }

            // 🔹 Deactivate Int_FFK_01_Floor_01 (23)
            GameObject floorObject = GameObject.Find("Int_FFK_01_Floor_01 (23)");
            if (floorObject != null)
            {
                floorObject.SetActive(false);
            }
            else
            {
                Debug.LogWarning("Int_FFK_01_Floor_01 (23) not found in scene.");
            }



            /*
                        // 🔹 Activate progress bar low (23)
                        GameObject Progress_bar_lowObject = GameObject.Find("progressbarlow");
                        if (Progress_bar_lowObject != null)
                        {
                            Progress_bar_lowObject.SetActive(true);
                        }
                        else
                        {
                            Debug.LogWarning("Progress Bar low not found in scene.");
                        }
            */

           

            // 🔹 Disable BoxCollider on Door
            GameObject doorObject = GameObject.Find("ExtInt_FFK_Door_01_01.001");
            if (doorObject != null)
            {
                BoxCollider collider2 = doorObject.GetComponent<BoxCollider>();
                if (collider2 != null)
                {
                    collider2.enabled = false;
                }
                else
                {
                    Debug.LogWarning("No BoxCollider found on FFK_Table_01_01 (2)");
                }
            }
            else
            {
                Debug.LogWarning("FFK_Table_01_01 (2) not found in scene.");
            }

           

        }

    }


}
