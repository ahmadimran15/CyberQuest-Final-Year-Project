using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class PuzzleManager : MonoBehaviour
{
    public Transform[] slots;           // 10 fixed slot positions (empty GameObjects)
    public GameObject[] tiles;          // 10 tile GameObjects (buttons with images)
    public int blankTileIndex = 0;      // Which slot currently holds the blank tile
    public TextMeshProUGUI feedbackText;
    public float slideDuration = 0.2f;
    public AudioSource slideSound;

    private int[] tilePositions;

    [Header("Voice Clips for Task Texts")]
    public AudioSource audioSource;
    public AudioClip clip_staringsoundPuzzle;

    // The expected tile indices at each slot for a solved puzzle
    public int[] solvedTileOrder;


    private void PlayAudio(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        }
    }


    void Start()
    {


        tilePositions = new int[tiles.Length];
        for (int i = 0; i < tiles.Length; i++)
        {
            tilePositions[i] = i;
            tiles[i].transform.position = slots[i].position;
        }

        // Example default solved order if not set via Inspector (optional)
        if (solvedTileOrder == null || solvedTileOrder.Length != slots.Length)
        {
            solvedTileOrder = new int[slots.Length];
            for (int i = 0; i < slots.Length; i++)
            {
                solvedTileOrder[i] = i;
            }
        }
    }

    public void TryMoveTile(int tileIndex)
    {
        // Find the current slot of the tile we want to move
        int tileSlotIndex = -1;
        for (int i = 0; i < tilePositions.Length; i++)
        {
            if (tilePositions[i] == tileIndex)
            {
                tileSlotIndex = i;
                break;
            }
        }

        if (tileSlotIndex == -1)
        {
            Debug.LogError($"Tile index {tileIndex} not found in any slot!");
            return;
        }

        Debug.Log($"Trying to move tile at slot: {tileSlotIndex} (Blank at slot: {blankTileIndex})");

        if (IsAdjacent(tileSlotIndex, blankTileIndex))
        {
            StartCoroutine(SwapTiles(tileSlotIndex, blankTileIndex));
        }
        else
        {
            Debug.Log("Tile is not adjacent to blank tile. Move ignored.");
        }
    }


    IEnumerator SwapTiles(int slotA, int slotB)
    {
        int tileAIndex = tilePositions[slotA];
        int tileBIndex = tilePositions[slotB];

        GameObject tileA = tiles[tileAIndex];
        GameObject tileB = tiles[tileBIndex];

        Vector3 posA = slots[slotA].position;
        Vector3 posB = slots[slotB].position;

        if (slideSound != null)
            slideSound.Play();

        float elapsed = 0f;
        while (elapsed < slideDuration)
        {
            tileA.transform.position = Vector3.Lerp(posA, posB, elapsed / slideDuration);
            tileB.transform.position = Vector3.Lerp(posB, posA, elapsed / slideDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        tileA.transform.position = posB;
        tileB.transform.position = posA;

        tilePositions[slotA] = tileBIndex;
        tilePositions[slotB] = tileAIndex;
        blankTileIndex = slotA;

        Debug.Log($"Tiles swapped between slots {slotA} and {slotB}. New blank slot index: {blankTileIndex}");

        DebugPrintTilePositions();
        CheckWinCondition();
    }

    // ✅ Keep your custom adjacency matrix here
    private bool IsAdjacent(int a, int b)
    {
        int[][] adjacencyMap = new int[][]
        {
            new int[] {1},           // 0
            new int[] {0, 2, 4},     // 1
            new int[] {1, 3, 5},     // 2
            new int[] {2, 6},        // 3
            new int[] {1, 5, 7},     // 4
            new int[] {2, 4, 6, 8},  // 5
            new int[] {3, 5, 9},     // 6
            new int[] {4, 8},        // 7
            new int[] {5, 7, 9},     // 8
            new int[] {6, 8},        // 9
        };

        foreach (int neighbor in adjacencyMap[a])
        {
            if (neighbor == b)
                return true;
        }

        return false;
    }

    private void CheckWinCondition()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (tilePositions[i] != solvedTileOrder[i])
            {
                Debug.Log($"Slot {i} has tile {tilePositions[i]}, expected {solvedTileOrder[i]}. Not solved.");
                return;
            }
        }

        Debug.Log("🎉 Puzzle Solved!");
        DisplayFeedbackText("Congratulations! You Solved the Puzzle!");

        PuzzleState.puzzleSolved = true;

        // ✅ Set both puzzle flags
        CutSceneFlags.puzzlesolved1 = true;
        CutSceneFlags.puzzlesolved2 = true;
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("LaptopScreen");
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "LaptopScreen")
        {
            GameObject.Find("PDF_Button")?.SetActive(true);
            GameObject.Find("PDF_ButtonLocked")?.SetActive(false);

            GameObject feedbackGO = GameObject.Find("FeedbackText");
            if (feedbackGO != null)
            {
                var tmp = feedbackGO.GetComponent<TextMeshProUGUI>();
                if (tmp != null)
                {
                    tmp.text = "File Unlocked";
                    tmp.fontStyle = FontStyles.Normal;
                    tmp.fontSize = 72f;
                }
            }

            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    private void DisplayFeedbackText(string message)
    {
        if (feedbackText != null)
        {
            feedbackText.text = message;
            feedbackText.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("FeedbackText is not assigned!");
        }
    }

    /* public void ReloadPuzzle()
     {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     }*/

    private void DebugPrintTilePositions()
    {
        string positions = "Current tile positions by slot: ";
        for (int i = 0; i < tilePositions.Length; i++)
        {
            positions += tilePositions[i] + (i < tilePositions.Length - 1 ? ", " : "");
        }
        Debug.Log(positions);
    }

}