using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Attack5MainScript : MonoBehaviour
{
    public GameObject eventPanel;
    public GameObject riddle1Panel;
    public GameObject riddle2Panel;
   
    private bool clicked = false;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI feedbackText;
    public string[] correctAnswers = { "Password", "Spyware", "Trojan" };
    private string[] selectedAnswers = new string[3];
    private int currentIndex = 0;
    public GameObject submitButton;

    private float timeLeft = 90f;
    private bool riddleSolved = false;
    private float timer;
    private bool isActive = false;

    public Image progressBarFill;      
    public TextMeshProUGUI progressText; 

    private float currentProgress = 100f; 
    private float maxProgress = 100f;
    private Coroutine timerCoroutine;
    public Attack5Riddle2 attack5Riddle2Script;

    void OnEnable()
    {
        timeLeft = 90f;
        isActive = true;
        UpdateTimerUI();

        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);

        timerCoroutine = StartCoroutine(CountdownTimer());
    }
    IEnumerator CountdownTimer()
    {
        while (timeLeft > 0f)
        {
            timeLeft -= 1f;
            UpdateTimerUI();
            yield return new WaitForSeconds(1f);
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
        timer = timeLeft;
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



   /* void Update()
    {
        if (!isActive) return;


        timeLeft -= Time.deltaTime;
        UpdateTimerUI();

        if (timeLeft <= 0f)
        {
            TimerExpired();
        }
    }*/


    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60f);
        int seconds = Mathf.FloorToInt(timeLeft % 60f);
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

            if (selectedAnswers[i] != correctAnswers[i])
            {
                feedbackText.text = "Incorrect. Try again.";
                DeductRiddlePenalty();

                Invoke(nameof(ResetFeedback), 2f);
                ResetSelection();
                return;
            }
        }

        feedbackText.text = "Correct!";
        isActive = false;
        riddleSolved = true;
        // Stop timer
        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);
        //timeLeft = 90f;
        riddle2Panel.SetActive(true);
        attack5Riddle2Script.ActivateRiddle2();
        riddle1Panel.SetActive(false);
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

        isActive = false;
        feedbackText.text = "Time's up! Try again.";
        submitButton.SetActive(true); 
        Invoke(nameof(ResetRiddle), 2f);
    }
    void ResetRiddle()
    {
        riddleSolved = false;
        timeLeft = 90f;
        feedbackText.text = "";

        selectedAnswers = new string[3];
        currentIndex = 0;

        foreach (UnityEngine.UI.Button btn in FindObjectsOfType<UnityEngine.UI.Button>())
        {
            btn.interactable = true;
        }
    }


}
