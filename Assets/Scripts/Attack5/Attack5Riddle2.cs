using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Attack5Riddle2 : MonoBehaviour
{
   
    public GameObject progressBarObject;
    public Image progressBarFill;      
    public TextMeshProUGUI progressText; 
    private float currentProgress = 100f; 
    private float maxProgress = 100f;

    public GameObject riddle2Panel;
    public GameObject cutscene2;
    public GameObject winningPanel;
    public GameObject losePanel;
    public GameObject cutscene3;
    public GameObject scanPanel;
    public GameObject malwarePanel;
    public GameObject eventPanel;
    public GameObject choicePanel;
    public GameObject goodCutscene;
    public GameObject badCutscene;
    private bool clicked = false; 

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI feedbackText;
    public string[] correctAnswers = { "PhishingEmail", "MaliciousLink", "Keylogger" };
    private string[] selectedAnswers = new string[3];
    private int currentIndex = 0;
    public GameObject submitButton;

    private float timeLeft2 = 90f;
    private bool riddleSolved = false;
    private float timer;

    private Coroutine timerCoroutine;


    public void ActivateRiddle2()
    {
        // Stop any existing timer first
        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);

        // Reset all values
        timeLeft2 = 90f;
        riddleSolved = false;
        ResetSelection();
        feedbackText.text = "";

        // Activate panel
        riddle2Panel.SetActive(true);

        // Start fresh timer
        StartTimer();
    }

  /*  void OnEnable()
    {

        // Only start timer if riddle2Panel is actually active and we want to start
        if (riddle2Panel.activeInHierarchy)
        {
            timeLeft2 = 90f; // Ensure reset
            StartTimer();
        }
    }*/

    public void StartTimer()
    {
        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);

        timeLeft2 = 90f;
        UpdateTimerUI();
        timerCoroutine = StartCoroutine(TimerRoutine());
    }

    IEnumerator TimerRoutine()
    {
        while (timeLeft2 > 0f)
        {
            timeLeft2 -= Time.deltaTime;
            UpdateTimerUI();
            yield return null;
        }

        TimerExpired();
    }

   

    void UpdateProgressUI()
    {
        float fillAmount = currentProgress / maxProgress;
        progressBarFill.fillAmount = fillAmount;
        progressText.text = Mathf.Clamp(currentProgress, 0, maxProgress).ToString("0");
    }
    void Start()
    {
        timer = timeLeft2;
        UpdateProgressUI();
    }

    public void DeductRiddlePenalty()
    {
        currentProgress -= 2;
        UpdateProgressUI();
    }

    public void DeductSkipScanPenalty()
    {
        currentProgress -= 5;
        UpdateProgressUI();
    }

    public void AddScanReward()
    {
        currentProgress += 5;
        if (currentProgress > maxProgress) currentProgress = maxProgress;
        UpdateProgressUI();
    }


    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeLeft2 / 60f);
        int seconds = Mathf.FloorToInt(timeLeft2 % 60f);
        timerText.text = $"Time Left: {minutes:00}:{seconds:00}";
    }

    public void OnSubmitClicked()
    {
        if (clicked) return;

        clicked = true;

        Debug.Log("Submit clicked once.");

        CheckAnswer();
        Invoke(nameof(ResetClick), 0.5f);
    }

    void ResetClick()
    {
        clicked = false;
    }

    public void OnOptionSelected(string answer)
    {
        if (riddleSolved || currentIndex >= 3)
            return;

        for (int i = 0; i < currentIndex; i++)
        {
            if (selectedAnswers[i] == answer)
            {
                Debug.Log("Answer already selected.");
                return;
            }
        }

        Debug.Log("Selected: " + answer);
        selectedAnswers[currentIndex] = answer;
        currentIndex++;

        if (currentIndex == 3)
        {
            DisableAllOptionButtons();
           // CheckAnswer();
        }
    }

    void DisableAllOptionButtons()
    {
        foreach (UnityEngine.UI.Button btn in FindObjectsOfType<UnityEngine.UI.Button>())
        {
            btn.interactable = false;
        }
    }


    public void CheckAnswer()
    {
        for (int i = 0; i < correctAnswers.Length; i++)
        {
            Debug.Log($"Comparing {selectedAnswers[i]} with {correctAnswers[i]}");
            string selected = selectedAnswers[i]?.Trim();
            string correct = correctAnswers[i]?.Trim();

            if (!string.Equals(selected, correct, System.StringComparison.OrdinalIgnoreCase))
            {
                feedbackText.text = "Incorrect. Try again.";
                DeductRiddlePenalty();

                Invoke(nameof(ResetFeedback), 2f);
                ResetSelection();
                return;
            }
        }
      

        // All correct
        feedbackText.text = "Correct!";
        riddleSolved = true;
        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);
       // timeLeft2 = 90f;
        choicePanel.SetActive(true);
        riddle2Panel.SetActive(false);
    }

    void ResetFeedback()
    {
        feedbackText.text = "";
    }


    public void ResetSelection()
    {
        selectedAnswers = new string[3];
        currentIndex = 0;
        foreach (UnityEngine.UI.Button btn in FindObjectsOfType<UnityEngine.UI.Button>())
        {
            btn.interactable = true;
        }
    }

    void TimerExpired()
    {
        feedbackText.text = "Time's up! Try again.";
        submitButton.SetActive(true);
        Invoke(nameof(ResetRiddle), 2f);
    }
    void ResetRiddle()
    {
        riddleSolved = false;
        timeLeft2 = 90f;
        feedbackText.text = "";

        selectedAnswers = new string[3];
        currentIndex = 0;
        foreach (UnityEngine.UI.Button btn in FindObjectsOfType<UnityEngine.UI.Button>())
        {
            btn.interactable = true;
        }
    }


    public void OnOptionA()
    {
        AddScanReward();
        choicePanel.SetActive(false);
        scanPanel.SetActive(true);
        Invoke("StopScan", 3f);
    }


    private void StopScan()
    {
        scanPanel.SetActive(false);
        malwarePanel.SetActive(true);
        Invoke("MalwarePanelStop", 3f);
    }

    private void MalwarePanelStop()
    {
        malwarePanel.SetActive(false);
        eventPanel.SetActive(false);
        cutscene2.SetActive(true);
        Invoke("StopCutscene2", 9f);
    }

    private void StopCutscene2()
    {
        cutscene2.SetActive(false);
        goodCutscene.SetActive(true);
        Invoke("EndGoodCutscene", 9f);
    }
    private void EndGoodCutscene()
    {
        goodCutscene.SetActive(false);
        eventPanel.SetActive(true);
        winningPanel.SetActive(true);
    }

    public void OnOptionB()
    {
        DeductSkipScanPenalty();
        cutscene3.SetActive(true);
        eventPanel.SetActive(false);
        choicePanel.SetActive(false);
        Invoke("StopCutscene3", 4f);
    }
    private void StopCutscene3()
    {
        cutscene3.SetActive(false);
        badCutscene.SetActive(true);
        Invoke("EndbadCutscene", 9f);
    }

    private void EndbadCutscene()
    {
        badCutscene.SetActive(false);
        eventPanel.SetActive(true);
        losePanel.SetActive(true);
    }
}
