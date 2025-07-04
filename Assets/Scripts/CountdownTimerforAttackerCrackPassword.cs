using UnityEngine;
using TMPro;

public class CountdownTimerforAttackerCrackPassword : MonoBehaviour
{
    public float timeLeft = 30f;
    public int maxAttempts = 18;

    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI optionsLeftText;
    public TextMeshProUGUI feedbackText;

    public GameObject nextOnCorrect;  // Assign GameObject to activate if correct
    public GameObject nextOnFail;     // Assign GameObject to activate if failed
    public GameObject parentPanelToDeactivate; // Optional: assign main panel to deactivate

    [Header("Voice Clips for Feedback Texts")]
    public AudioSource audioSource;
    public AudioClip clip_wrongOption;


    private int attempts = 0;
    private bool selectionMade = false;


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
        UpdateUI();
    }

    void Update()
    {
        if (!selectionMade)
        {
            timeLeft -= Time.deltaTime;
            timeLeft = Mathf.Clamp(timeLeft, 0f, 999f);
            countdownText.text = "Time Left: " + Mathf.CeilToInt(timeLeft).ToString();

            if (timeLeft <= 0f)
            {
                selectionMade = true;
                SwitchToNext(nextOnFail);
            }
        }
    }

    public void OnOptionSelected(bool isCorrect)
    {
        if (selectionMade) return;

        if (isCorrect)
        {
            selectionMade = true;
            SwitchToNext(nextOnCorrect);
        }
        else
        {
            attempts++;
            UpdateUI();
            feedbackText.text = "Wrong Option! Try again.";
            PlayAudio(clip_wrongOption);

            if (attempts >= maxAttempts)
            {
                selectionMade = true;
                SwitchToNext(nextOnFail);
            }
        }
    }

    private void UpdateUI()
    {
        int remaining = maxAttempts - attempts;
        int displayOptions = 0;

        if (remaining > 12)
            displayOptions = 3;
        else if (remaining > 6)
            displayOptions = 2;
        else if (remaining > 0)
            displayOptions = 1;
        else
            displayOptions = 0;

        optionsLeftText.text = "Options Left: " + displayOptions.ToString();
    }

    /*private void UpdateUI()
    {
        int remainingChances = (maxAttempts - attempts);
        int optionsLeft = Mathf.CeilToInt(remainingChances / 6f);  // 18 attempts = 3 visible options

        // Clamp between 0 and 3 to be safe
        optionsLeft = Mathf.Clamp(optionsLeft, 0, 3);

        optionsLeftText.text = "Options Left: " + optionsLeft.ToString();
    }*/

    private void SwitchToNext(GameObject nextObject)
    {
        if (nextObject != null)
            nextObject.SetActive(true);

        if (parentPanelToDeactivate != null)
            parentPanelToDeactivate.SetActive(false);
        else
            gameObject.transform.root.gameObject.SetActive(false); // Fallback
    }
}
