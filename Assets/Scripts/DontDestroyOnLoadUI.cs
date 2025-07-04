using UnityEngine;

public class DontDestroyOnLoadUI : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject); // Keeps the UI across scenes
    }
}
