using UnityEngine;
using TMPro;

using UnityEngine.UI;
using System.Collections;

public class Attack6mainScript : MonoBehaviour
{
    public TextMeshProUGUI feedbackText;  // Link this to the feedback text in the Inspector
    public TextMeshProUGUI Tasktext;
    public RawImage targetImage; // Drag your UI Image (image2) here in the Inspector
    public Button Download;
    public Button OpenDirectory;
    public Button Downlaodedfiles;
    public RawImage targetzipimage;
    public RawImage Desktop;
    public RawImage Desktop_importantFiles;
    public RawImage Desktop_Personal;
    public RawImage Desktop_IEEE;
    public Image imageemailwhite;
    public TextMeshProUGUI EmailImage;

    [Header("Voice Clips for Task Texts")]
    public AudioSource audioSource;
    public AudioClip clip_SeekDownload;
    public AudioClip clip_FindTheFile;
    public AudioClip clip_Download2024_2025;

    private void Start()
    {

        if (!CutSceneFlags.puzzlesolved1)
        {
            // Set the starting text
            Tasktext.text = "The key lies in the corner securely download the 2024 - 2025 revelation before it vanishes.";
            // Play audio on start
            PlayAudio(clip_Download2024_2025);
        }
       
    }


    private void PlayAudio(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        }
    }




    public void OnDownloadButtonClicked()
    {
        feedbackText.text = "Download Started...";
        StartCoroutine(ShowSuccessAfterDelay(2f));
        Downlaodedfiles.gameObject.SetActive(true);
    }

    private IEnumerator ShowSuccessAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        feedbackText.text = "Downloaded Successfully!";
        Tasktext.text = "Seek the downward arrow atop the screen And Click to go to Directory";
        PlayAudio(clip_SeekDownload);
    }

    
    public void OnButtonClicked()
    {
        if (targetImage != null)
        {
            targetImage.gameObject.SetActive(true);
            targetzipimage.gameObject.SetActive(true);
            Download.gameObject.SetActive(false);
            OpenDirectory.gameObject.SetActive(true);
            feedbackText.text = "";
            

        }
        else
        {
            Debug.LogWarning("Target Image is not assigned in the Inspector!");
        }
    }

    public void FileOpenDirectory()
    {
        if (targetImage != null)
        {
            Desktop.gameObject.SetActive(true);
            targetImage.gameObject.SetActive(false);
            Downlaodedfiles.gameObject.SetActive(false);
            targetzipimage.gameObject.SetActive(false);
            OpenDirectory.gameObject.SetActive(false);
            imageemailwhite.gameObject.SetActive(false);
            EmailImage.gameObject.SetActive(false);
           // Download.gameObject.SetActive(false);
            feedbackText.text = "";
            Tasktext.text = "Two shadows lead nowhere the truth hides in the one that stands alone. Find the File";
            PlayAudio(clip_FindTheFile);

        }
        else
        {
            Debug.LogWarning("Target Image is not assigned in the Inspector!");
        }
    }

}
