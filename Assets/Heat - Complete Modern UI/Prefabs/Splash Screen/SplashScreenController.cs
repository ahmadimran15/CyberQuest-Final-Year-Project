using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenController : MonoBehaviour
{
    public string nextSceneName = "MainMenu";  // Set the name of your next scene here

    void Update()
    {
        // Detect if any key is pressed
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(nextSceneName);  // Load the next scene
        }
    }

}

