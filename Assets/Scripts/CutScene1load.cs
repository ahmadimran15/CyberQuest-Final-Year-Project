using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene1load : MonoBehaviour
{
    public GameObject onclick;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadCutscene()
    {
        SceneManager.LoadScene("Cutscene1"); // Ensure "Cutscene1" matches the exact scene name in Build Settings
    }
}
