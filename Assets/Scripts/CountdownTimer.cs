using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float timeLeft = 20f;
    public TextMeshProUGUI countdownText;

    public GameObject failurePanel; // Assign this in the inspector
    public GameObject currentPanel; // Optional: to deactivate the current panel

    private bool collided = false;

    void Update()
    {
        if (!collided)
        {
            timeLeft -= Time.deltaTime;
            timeLeft = Mathf.Clamp(timeLeft, 0, 999f);
            countdownText.text = "Time Left: " + Mathf.CeilToInt(timeLeft).ToString();

            if (timeLeft <= 0f)
            {
                collided = true;
                if (currentPanel != null)
                    currentPanel.SetActive(false);

                if (failurePanel != null)
                    failurePanel.SetActive(true);
            }
        }
    }

    public void StopTimerOnCollision()
    {
        collided = true;
    }
}


/*using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float timeLeft = 20f;
    public TextMeshProUGUI countdownText;

    private bool collided = false;

    void Update()
    {
        if (!collided)
        {
            timeLeft -= Time.deltaTime;
            timeLeft = Mathf.Clamp(timeLeft, 0, 999f); // Prevent negative values
            countdownText.text = "Time Left: " + Mathf.CeilToInt(timeLeft).ToString();

            if (timeLeft <= 0f)
            {
                // Time ran out – optionally handle failure
                SceneManager.LoadScene("Level_Failed_Screen"); // or show a message, etc.
            }
        }
    }

    public void StopTimerOnCollision()
    {
        collided = true;
    }
}
*/