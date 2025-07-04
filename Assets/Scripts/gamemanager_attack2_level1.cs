using UnityEngine;
using TMPro;

public class gamemanager_attack2_level1 : MonoBehaviour
{
    public static TaskManager Instance; // Singleton for global access
    public TextMeshProUGUI taskText;

    [Header("Voice Clips for Task Texts")]
    public AudioSource audioSource;
    public AudioClip clip_findphone;


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
        PlayAudio(clip_findphone);

    }


}
