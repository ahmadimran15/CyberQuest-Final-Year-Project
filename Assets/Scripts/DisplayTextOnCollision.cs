using UnityEngine;
using TMPro;

public class DisplayTextOnCollision : MonoBehaviour
{
    private TextMeshProUGUI textToShow;

    void Start()
    {
        // Automatically find TextMeshPro object by name
        GameObject textObject = GameObject.Find("Man (1)");
        if (textObject != null)
        {
            textToShow = textObject.GetComponent<TextMeshProUGUI>();
            textToShow.gameObject.SetActive(false); // Hide text initially
        }
        else
        {
            Debug.LogError("TextMeshProUGUI object named 'TextMeshPro' NOT found! Check your Hierarchy.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera")) // Ensure Main Camera is tagged correctly
        {
            if (textToShow != null)
            {
                textToShow.gameObject.SetActive(true);
                Debug.Log("Camera collided with Man (1). Text displayed.");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (textToShow != null)
            {
                textToShow.gameObject.SetActive(false);
                Debug.Log("Camera left Man (1). Text hidden.");
            }
        }
    }
}
