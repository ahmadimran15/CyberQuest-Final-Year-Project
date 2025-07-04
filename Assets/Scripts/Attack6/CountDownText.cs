using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class CountDownText : MonoBehaviour

{
    [Header("Voice Clips for Task Texts")]
    public AudioSource audioSource;
    public AudioClip clip_staringsoundPuzzle;
    public AudioClip clip_30SecondsLeft;

    private bool hasPlayed30SecondClip = false;

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
        if (!CutSceneFlags.puzzlestartingvoice)
        {
            PlayAudio(clip_staringsoundPuzzle);
            CutSceneFlags.puzzlestartingvoice = true;
        }

    }

    public float timeLeft = 30f;
    public TextMeshProUGUI countdownText;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeft = Mathf.Clamp(timeLeft, 0f, 999f);

        if (!hasPlayed30SecondClip && timeLeft <= 30f)
        {
            PlayAudio(clip_30SecondsLeft);
            hasPlayed30SecondClip = true;
        }

        // Calculate minutes and seconds from timeLeft
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);

        // Format the time string as mm:ss
        countdownText.text = string.Format("Time Left: {0}:{1:00}", minutes, seconds);

        if (timeLeft <= 0f)
        {
            SceneManager.LoadScene("Attack6_Puzzle_Failed_Screen");
        }
    }

}