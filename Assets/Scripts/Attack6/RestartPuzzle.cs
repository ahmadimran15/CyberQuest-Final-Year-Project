using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartPuzzle : MonoBehaviour
{
    public void RestartLevel()  // Renamed method
    {
        SceneManager.LoadScene("3x3PuzzleNew");
    }
}
