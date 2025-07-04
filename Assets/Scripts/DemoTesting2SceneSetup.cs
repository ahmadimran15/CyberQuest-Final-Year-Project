using UnityEngine;
using TMPro;

public class DemoTesting2SceneSetup : MonoBehaviour
{
    [Header("Assigned GameObjects")]
    public GameObject noCutsceneObject;
    public GameObject taskTextObject;
    public GameObject libraryManager;

    [Header("Voice Clips for Task Texts")]
    public AudioSource audioSource;
    public AudioClip clip_explorelibrary;


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
        // ✅ Only if No was clicked
        if (CutSceneFlags.noClicked)
        {
            // Enable nocutscene script
            if (noCutsceneObject != null)
            {
                noCutsceneObject.GetComponent<NOCutsceneLoading>().enabled = true;
                Debug.Log("NOCutsceneLoading script enabled.");
            }

            // Update Task Text
            if (taskTextObject != null)
            {
                var taskText = taskTextObject.GetComponent<TextMeshProUGUI>();
                if (taskText != null)
                {
                    taskText.text = "Explore the Library";
                    PlayAudio(clip_explorelibrary);
                }
            }

            // Disable LibraryManager
            if (libraryManager != null)
            {
                libraryManager.SetActive(false);
                Debug.Log("LibraryManager Disabled.");
            }

            // Optional: Reset the flag
            // CutSceneFlags.noClicked = false;
        }
    }
}



/*using UnityEngine;
using TMPro;

public class DemoTesting2SceneSetup : MonoBehaviour
{
    void Start()
    {
        // ✅ Only if No was clicked
        if (CutSceneFlags.noClicked)
        {
            // Enable nocutscene script
            GameObject nocutsceneObj = GameObject.Find("nocutscene");
            if (nocutsceneObj != null)
            {
                nocutsceneObj.GetComponent<NOCutsceneLoading>().enabled = true;
                Debug.Log("NOCutsceneLoading script enabled.");
            }

            // Update Task Text
            GameObject taskObject = GameObject.Find("TaskText");
            if (taskObject != null)
            {
                var taskText = taskObject.GetComponent<TextMeshProUGUI>();
                taskText.text = "Explore the Library";
            }

            // Optional: Disable LibraryManager
            GameObject libraryManager = GameObject.Find("LibraryManager");
            if (libraryManager != null)
            {
                libraryManager.SetActive(false);
                Debug.Log("LibraryManager Disabled.");
            }

            // Reset flag if you want it to only trigger once
            // CutSceneFlags.noClicked = false;   // Optional
        }
    }
}*/
