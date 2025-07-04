using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class DesktopManager : MonoBehaviour
{

    //public TextMeshProUGUI feedbackText;  // Link this to the feedback text in the Inspector
    public TextMeshProUGUI feedbackText;  // Link this to the feedback text in the Inspector
    public TextMeshProUGUI StatusText;  // Link this to the feedback text in the Inspector  // Link this to the feedback text in the Inspector
    public TextMeshProUGUI TaskText;
    public RawImage Desktop;
    public RawImage ImageStarting;
    public RawImage Desktop_importantFiles;
    public RawImage Desktop_Personal;
    public RawImage Desktop_IEEEZip;
    public RawImage DesktopAfterAttack;
    public RawImage BlackScreen_Restarting;
    public RawImage IEEEZip_Readme;
    public RawImage Attacker_Readme;
    public Image UsbOptions;
    public RawImage ImportantFiles_Readme;
    public Button Desktop_importantFiles_button;
    public Button Desktop_Personal_button;
    public Button Desktop_IEEEZip_button;
    public Button Desktop_IEEE_PDF_button;
    public Button Desktop_IEEE_PDF_button_locked;
    public Button USB_backupData;
    public Button USB_DontBackupData;
    public GameObject exitScreen;
    public GameObject UsbinsertingCutscene;
    public GameObject AntivirusOptions;


    [Header("Voice Clips for Task Texts")]
    public AudioSource audioSource;
    public AudioClip clip_FindTheFile;
    public AudioClip clip_ReadAfterChaos;
    public AudioClip clip_CloseFileTopRight;
    public AudioClip clip_YourWorldDark;
    public AudioClip clip_fileunlocked;


    private void PlayAudio(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        }
    }


    public void openDesktop_importantFiles()
    {
        if (Desktop != null)
        {
            Desktop_importantFiles.gameObject.SetActive(true);
            Desktop.gameObject.SetActive(false);
            Desktop_importantFiles_button.gameObject.SetActive(false);
            Desktop_IEEEZip_button.gameObject.SetActive(false);
            Desktop_Personal_button.gameObject.SetActive(false);

        }
        else
        {
            Debug.LogWarning("Target Image is not assigned in the Inspector!");
        }
    }


     public void openDesktop_Personal()
    {
        if (Desktop != null)
        {
            Desktop_Personal.gameObject.SetActive(true);
            Desktop.gameObject.SetActive(false);
            Desktop_importantFiles_button.gameObject.SetActive(false);
            Desktop_IEEEZip_button.gameObject.SetActive(false);
            Desktop_Personal_button.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Target Image is not assigned in the Inspector!");
        }
    }


    public void openDesktop_ieezip()
    {
        if (Desktop != null)
        {
            Desktop_IEEEZip.gameObject.SetActive(true);
            Desktop.gameObject.SetActive(false);
            Desktop_importantFiles_button.gameObject.SetActive(false);
            Desktop_IEEEZip_button.gameObject.SetActive(false);
            Desktop_Personal_button.gameObject.SetActive(false);

        }
        else
        {
            Debug.LogWarning("Target Image is not assigned in the Inspector!");
        }
    }

    public void backButtonfromIeee()
    {
        if (Desktop != null)
        {
            Desktop_IEEEZip.gameObject.SetActive(false);
            Desktop.gameObject.SetActive(true);
            Desktop_importantFiles_button.gameObject.SetActive(true);
            Desktop_IEEEZip_button.gameObject.SetActive(true);
            Desktop_Personal_button.gameObject.SetActive(true);

        }
        else
        {
            Debug.LogWarning("Target Image is not assigned in the Inspector!");
        }
    }

    public void backButtonfromImportantfiles()
    {
        if (Desktop != null)
        {
            Desktop_importantFiles.gameObject.SetActive(false);
            Desktop.gameObject.SetActive(true);
            Desktop_importantFiles_button.gameObject.SetActive(true);
            Desktop_IEEEZip_button.gameObject.SetActive(true);
            Desktop_Personal_button.gameObject.SetActive(true);

        }
        else
        {
            Debug.LogWarning("Target Image is not assigned in the Inspector!");
        }
    }

    public void backButtonfromPersonal()
    {
        if (Desktop != null)
        {
            Desktop_Personal.gameObject.SetActive(false);
            Desktop.gameObject.SetActive(true);
            Desktop_importantFiles_button.gameObject.SetActive(true);
            Desktop_IEEEZip_button.gameObject.SetActive(true);
            Desktop_Personal_button.gameObject.SetActive(true);

        }
        else
        {
            Debug.LogWarning("Target Image is not assigned in the Inspector!");
        }
    }

    public void Openreadme_IEEEzip()
    {
            
            IEEEZip_Readme.gameObject.SetActive(true);
            Desktop_Personal.gameObject.SetActive(false);
            Desktop.gameObject.SetActive(false);
            TaskText.text = "If you want to Close the File than from top right";
            PlayAudio(clip_CloseFileTopRight);
            Desktop_importantFiles_button.gameObject.SetActive(false);
            //backButtonfromIeee.gameObject.SetActive(false);
    }

    public void LoadPuzzle()
    {
        
        //Desktop_IEEEZip.gameObject.SetActive(true);

        Desktop_IEEE_PDF_button_locked.gameObject.SetActive(false);
        Desktop_IEEE_PDF_button.gameObject.SetActive(true);
        SceneManager.LoadScene("3x3PuzzleNew");
    }

    public void OpenAntivirus_Options()
    {

        //Desktop_IEEEZip.gameObject.SetActive(true);

        Desktop_IEEE_PDF_button_locked.gameObject.SetActive(false);
        Desktop_IEEE_PDF_button.gameObject.SetActive(true);
        AntivirusOptions.gameObject.SetActive(true);
        ImageStarting.gameObject.SetActive(false);
        Desktop_IEEEZip.gameObject.SetActive(false);
    }


    public void Openreadme_ImportantFiles()
    {

        ImportantFiles_Readme.gameObject.SetActive(true);
        Desktop_importantFiles.gameObject.SetActive(false);
        Desktop_Personal.gameObject.SetActive(false);
        Desktop.gameObject.SetActive(false);
        TaskText.text = "If you want to Close the File than from top right";
        PlayAudio(clip_CloseFileTopRight);
        Desktop_importantFiles_button.gameObject.SetActive(false);
        //backButtonfromIeee.gameObject.SetActive(false);
    }

    public void backbutton_fromimportantfiles_readme()
    {

        ImportantFiles_Readme.gameObject.SetActive(false);
        Desktop_importantFiles.gameObject.SetActive(true);
        Desktop_Personal.gameObject.SetActive(false);
        Desktop.gameObject.SetActive(false);

        TaskText.text = "Two shadows lead nowhere the truth hides in the one that stands alone. Find the File";
        PlayAudio(clip_FindTheFile);
        Desktop_importantFiles_button.gameObject.SetActive(false);
        //backButtonfromIeee.gameObject.SetActive(false);
    }

    public void backbutton_fromIEEzip_readme()
    {

        IEEEZip_Readme.gameObject.SetActive(false);
        Desktop_IEEEZip.gameObject.SetActive(true);
        Desktop_Personal.gameObject.SetActive(false);
        Desktop.gameObject.SetActive(false);

        TaskText.text = "Two shadows lead nowhere the truth hides in the one that stands alone. Find the File";
        PlayAudio(clip_FindTheFile);
        Desktop_importantFiles_button.gameObject.SetActive(false);
        //backButtonfromIeee.gameObject.SetActive(false);
    }

    public void backbutton_fromattacker_readme()
    {

        Attacker_Readme.gameObject.SetActive(false);
        DesktopAfterAttack.gameObject.SetActive(true);
        Desktop_Personal.gameObject.SetActive(false);
        Desktop.gameObject.SetActive(false);
        Desktop_importantFiles_button.gameObject.SetActive(false);
        TaskText.text = "Your world’s gone dark and we turned off the lights";
        PlayAudio(clip_YourWorldDark);
        //backButtonfromIeee.gameObject.SetActive(false);
        StartCoroutine(ActivateOtherAfterDelay(4f));
    }

    private IEnumerator ActivateOtherAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        TaskText.text = "";
        UsbOptions.gameObject.SetActive(true);
    }


    public void Openreadme_Attacker_readme()
    {
        Attacker_Readme.gameObject.SetActive(true);
        DesktopAfterAttack.gameObject.SetActive(false);
        Desktop_Personal.gameObject.SetActive(false);
        Desktop.gameObject.SetActive(false);
        TaskText.text = "If you want to Close the File than from top right";
        PlayAudio(clip_CloseFileTopRight);
        Desktop_importantFiles_button.gameObject.SetActive(false);

      
    }

    


public void open_IEEEPDFFile()
    {
        StartCoroutine(HandleIEEEScreenTransitionnew());
    }

    private IEnumerator HandleIEEEScreenTransitionnew()
    {
        BlackScreen_Restarting.gameObject.SetActive(true);
        Desktop_IEEEZip.gameObject.SetActive(false);
        Desktop_Personal.gameObject.SetActive(false);
        Desktop.gameObject.SetActive(false);
        Desktop_importantFiles_button.gameObject.SetActive(false);
        Desktop_IEEE_PDF_button_locked.gameObject.SetActive(false);
        feedbackText.text = "Restarting....";
        TaskText.text = "";

        yield return new WaitForSeconds(5f);

        BlackScreen_Restarting.gameObject.SetActive(false);
        feedbackText.text = "";
        TaskText.text = "The silence after chaos leaves one message. Time to read.";
        PlayAudio(clip_ReadAfterChaos);
        DesktopAfterAttack.gameObject.SetActive(true);
    }

    public void open_IEEEPDFFile_locked()
    {
        feedbackText.text = "File Locked... See Readme";
        StartCoroutine(ClearFeedbackAfterDelay(2f)); // 2 seconds delay
    }

    private IEnumerator ClearFeedbackAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        feedbackText.text = "";
    }


    public void backupData()
    {
        // Find and disable the backup button GameObject
        GameObject backupButtonObj = GameObject.Find("backupData");
        if (backupButtonObj != null)
        {
            backupButtonObj.SetActive(false);
        }

        // Find and disable the don't backup button GameObject
        GameObject noBackupButtonObj = GameObject.Find("DontBackupData");
        if (noBackupButtonObj != null)
        {
            noBackupButtonObj.SetActive(false);
        }

        // Start the backup simulation
        StartCoroutine(SimulateBackupFailure());
    }

    public void dont_backupData()
    {
        // Find and disable the backup button GameObject
        GameObject backupButtonObj = GameObject.Find("backupData");
        if (backupButtonObj != null)
        {
            backupButtonObj.SetActive(false);
        }

        // Find and disable the don't backup button GameObject
        GameObject noBackupButtonObj = GameObject.Find("DontBackupData");
        if (noBackupButtonObj != null)
        {
            noBackupButtonObj.SetActive(false);
        }
        SceneManager.LoadScene("CutscenePositive_Dontbackup_Attack6");

    }




    public void HidePopUpReadme()
    {
        exitScreen.SetActive(false);
        
    }

    public void OpenLevelfailedscreen()
    {
        SceneManager.LoadScene("Level_Failed_Screen_Attack6");


    }
    public void OpenLevelPassedscreen()
    {
        SceneManager.LoadScene("Level_Passed_Screen_Attack6");

    }

    public void opencutscenePositive()
    {
        SceneManager.LoadScene("CutscenePositive_Attack6");

    }

    public void opencutsceneNegative()
    {
        SceneManager.LoadScene("CutsceneNegative_Attack6");

    }



    private IEnumerator SimulateBackupFailure()
    {
        StatusText.text = "Plugging in USB...";
        yield return new WaitForSeconds(2f);

        StatusText.text = "Starting Backup...";
        yield return new WaitForSeconds(3f);

        StatusText.text = "Getting Issues While Transferring...";
        yield return new WaitForSeconds(2f);

        StatusText.text = "USB Got Corrupted. Backup Failed!";
        // Optional: Add sound or visual cue for failure

        yield return new WaitForSeconds(2f);
        exitScreen.SetActive(true);
    }

    public void DisableAntivirus()
    {
        LoadPuzzle();
        AntivirusOptions.gameObject.SetActive(false);
       
    }

    public void Dont_DisableAntivirus()
    {
        OpenLevelPassedscreen();
        AntivirusOptions.gameObject.SetActive(false);
        SceneManager.LoadScene("CutscenePositive_Attack6");
    }



    public void open_usbcutscene()
    {
        StartCoroutine(PlayCutscene());
    }

    


    private IEnumerator PlayCutscene()
    {
        UsbinsertingCutscene.gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        UsbinsertingCutscene.gameObject.SetActive(false);
        UsbOptions.gameObject.SetActive(true);
    }

    void Start()
    {
        if (PuzzleState.puzzleSolved)
        {
            Desktop_IEEEZip.gameObject.SetActive(true);
            Desktop_IEEE_PDF_button_locked.gameObject.SetActive(false);
            Desktop_IEEE_PDF_button.gameObject.SetActive(true);
            if (!CutSceneFlags.puzzlesolved1)
            {
                TaskText.text = "Two shadows lead nowhere the truth hides in the one that stands alone. Find the File";
                PlayAudio(clip_FindTheFile);
            }

            else
            {
                TaskText.text = "File Unlocked Successfully. Open the file";
                PlayAudio(clip_fileunlocked);
            }

            if (feedbackText != null)
            {
                StartCoroutine(ShowTemporaryMessage("File Unlocked", 72f, 2f));
            }
        }
    }

    private IEnumerator ShowTemporaryMessage(string message, float fontSize, float duration)
    {
        feedbackText.text = message;
        feedbackText.fontStyle = FontStyles.Normal;
        feedbackText.fontSize = fontSize;
        feedbackText.gameObject.SetActive(true);

        yield return new WaitForSeconds(duration);

        feedbackText.text = "";
    }


    /*public void OnDownloadButtonClicked()
    {
        feedbackText.text = "Download Started...";
        StartCoroutine(ShowSuccessAfterDelay(2f));
        Downlaodedfiles.gameObject.SetActive(true);
    }

    private IEnumerator ShowSuccessAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        feedbackText.text = "Downloaded Successfully!";
    }*/


    /*public void OnButtonClicked()
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
*/


}
