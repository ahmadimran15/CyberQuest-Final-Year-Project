using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance; // Singleton for global access
    public TextMeshProUGUI taskText;

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



    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep task text across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    void Start()
    {

        PlayAudio(clip_explorelibrary);
        // Check flag on scene start
        if (CutSceneFlags.noClicked)
        {
            UpdateTask("Explore the Library");
            PlayAudio(clip_explorelibrary);
        }
    }

    public void UpdateTask(string newTask)
    {
        if (taskText != null)
        {
            taskText.text = newTask;
        }
        else
        {
            Debug.LogError("Task Text not assigned in TaskManager!");
        }
    }
}
