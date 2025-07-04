using UnityEngine;
using TMPro;

public class taskmanagerAttack2 : MonoBehaviour
{
    public static TaskManager Instance; // Singleton for global access
    public TextMeshProUGUI taskText;

    [Header("Voice Clips for Task Texts")]
    public AudioSource audioSource;
    public AudioClip clip_exittocafe;


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
        PlayAudio(clip_exittocafe);
        
    }

    
}
