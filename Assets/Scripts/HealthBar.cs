using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public Image moodIcon;
    public Sprite happySprite;
    public Sprite sadSprite;
    public Sprite cryingSprite;

    public Text reputationText; // UI Text for reputation
    private int reputationPoints = 0;


    public RectTransform moodTransform;

    //public float slideDuration = 0.5f; 
    //public float slideDistance = 30f;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
        UpdateMoodIcon(); // Update mood when setting max health
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        UpdateMoodIcon();
    }

    public void UpdateReputation(int change)
    {
        reputationPoints += change;
        reputationText.text = "Reputation: " + reputationPoints;
        UpdateMoodIcon();
    }


    void UpdateMoodIcon()
    {
        float healthPercentage = slider.value / slider.maxValue;

        if (slider.value <= 0)
        {
            moodIcon.sprite = cryingSprite;
        }
        else if (healthPercentage <= 0.49f)
        {
            moodIcon.sprite = sadSprite;
        }
        else
        {
            moodIcon.sprite = happySprite;
        }
    }

    /* void SlideMoodIcon()
     {
         StartCoroutine(SlideLeft());
     }

     IEnumerator SlideLeft()
     {
         Vector2 startPos = moodTransform.anchoredPosition;
         Vector2 endPos = new Vector2(startPos.x - slideDistance, startPos.y);

         float elapsedTime = 0f;
         while (elapsedTime < slideDuration)
         {
             moodTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, elapsedTime / slideDuration);
             elapsedTime += Time.deltaTime;
             yield return null;
         }

         moodTransform.anchoredPosition = endPos;
     }

     void ResetMoodIconPosition()
     {
         StartCoroutine(SlideRight());
     }

     IEnumerator SlideRight()
     {
         Vector2 startPos = moodTransform.anchoredPosition;
         Vector2 endPos = new Vector2(startPos.x + slideDistance, startPos.y);

         float elapsedTime = 0f;
         while (elapsedTime < slideDuration)
         {
             moodTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, elapsedTime / slideDuration);
             elapsedTime += Time.deltaTime;
             yield return null;
         }

         moodTransform.anchoredPosition = endPos;
     }
    */

}