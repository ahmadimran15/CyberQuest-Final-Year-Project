using UnityEngine;
using UnityEngine.SceneManagement;

public class MainmenuTogame : MonoBehaviour
{
    public GameObject attack2and3Image; // Drag the UI Image GameObject here
    //public GameObject MainCOntent; // Drag the UI Image GameObject here
     public GameObject attack4Image;
    public GameObject attack6Image;


    public void LoadGamesceneAttack2and3()
    {
        StartCoroutine(ShowImageAndLoadScene());
    }

    private System.Collections.IEnumerator ShowImageAndLoadScene()
    {
        /*if (attack2and3Image != null)
        {
            attack2and3Image.SetActive(true);
            yield return new WaitForSeconds(2f);
            attack2and3Image.SetActive(false);
        }

        SceneManager.LoadScene("Level1");
*/

        if (attack2and3Image != null)
        {
            attack2and3Image.SetActive(true);
        }

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("Level1");
        yield return new WaitForSeconds(0.5f);

        if (attack2and3Image != null)
        {
            attack2and3Image.SetActive(false);
        }
    }


    public void LoadGamesceneAttack4()
    {
        StartCoroutine(ShowImageAndLoadSceneAttack4()); // Ensure "Cutscene1" matches the exact scene name in Build Settings
    }

    private System.Collections.IEnumerator ShowImageAndLoadSceneAttack4()
    {
        if (attack4Image != null)
        {
            attack4Image.SetActive(true);
        }

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("CafeSceneAttack4");
        yield return new WaitForSeconds(0.5f);

        if (attack4Image != null)
        {
            attack4Image.SetActive(false);
        }


    }

    public void LoadGamesceneAttack3()
    {
        SceneManager.LoadScene("CafeSceneAttack2and3"); // Ensure "Cutscene1" matches the exact scene name in Build Settings
    }

    public void LoadGamesceneAttack5()
    {
       // SceneManager.LoadScene("3x3PuzzleNew");
        
        SceneManager.LoadScene("testingAttack5"); // Ensure "Cutscene1" matches the exact scene name in Build Settings
    }

    public void LoadGamesceneAttack6()
    {
        StartCoroutine(ShowImageAndLoadSceneAttack6());
       
    }

    private System.Collections.IEnumerator ShowImageAndLoadSceneAttack6()
    {
        if (attack6Image != null)
        {
            attack6Image.SetActive(true);
        }

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("demotesting");
        yield return new WaitForSeconds(0.5f);

        if (attack6Image != null)
        {
            attack6Image.SetActive(false);
        }

    }


}
