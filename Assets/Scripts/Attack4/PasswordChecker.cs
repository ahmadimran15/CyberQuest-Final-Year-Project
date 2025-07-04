using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class PasswordChecker : MonoBehaviour
{
    public Image[] slotImages;              // Drag slot1 > Image, etc.
    public Sprite[] correctOrder;           // Drag correct password order
    public TextMeshProUGUI feedbackText;

    public DraggableImage[] draggableImages; // All draggable objects

    public void CheckPassword()
    {
        for (int i = 0; i < slotImages.Length; i++)
        {
            if (slotImages[i].sprite != correctOrder[i])
            {
                feedbackText.text = "❌ Incorrect password!";
                //Invoke(nameof(ResetPuzzle), 1.5f); // Delay reset for clarity
                return;
            }
        }

        feedbackText.text = "✅ Correct password entered!"; 
        Invoke(nameof(LoadNextScene), 1.5f);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("CutscenePasswordWifiattack4");
    }


    public void ResetPuzzle()
    {
        // Reload the current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    /*public void ResetPuzzle()
    {
        // 1. Clear slot images
        foreach (var img in slotImages)
        {
            img.sprite = null;
           
        }

      *//*  // 2. Reset draggable images to original position
        foreach (var dragImg in draggableImages)
        {
            dragImg.ResetToOriginal();
        }*//*

        
    }*/

}
