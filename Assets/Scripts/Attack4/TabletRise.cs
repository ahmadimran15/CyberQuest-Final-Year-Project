using UnityEngine;
using System.Collections;

public class TabletRise : MonoBehaviour
{
    [Header("Tablet ID (1 to 4) to identify which flag to trigger")]
    [Range(1, 4)]
    public int tabletID;

    [Header("Tablet object to move")]
    public Transform tabletObject;

    [Header("Target position in front of player")]
    public Transform targetPosition;

    [Header("Move animation speed")]
    public float moveSpeed = 2.0f;

    [Header("Rotate toward user")]
    public bool faceCamera = true;

    [Header("Optional: Sound")]
    public AudioSource audioSource;

    private bool isMoving = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Camera" && !isMoving)
        {
            Debug.Log("📡 Trigger entered by Main Camera!");

            Debug.Log($"📌 Current Tablet ID: {tabletID}");

            
            StartCoroutine(MoveTablet());

            SetTabletSeenFlag();
        }
        else
        {
            Debug.Log("❌ Trigger ignored: " + other.gameObject.name);
        }
    }

    void SetTabletSeenFlag()
    {
        switch (tabletID)
        {
            case 1:
                CutSceneFlags.Image1Seen = true;
                Debug.Log("✅ Image1Seen is now TRUE.");
                break;
            case 2:
                CutSceneFlags.Image2Seen = true;
                Debug.Log("✅ Image2Seen is now TRUE.");
                break;
            case 3:
                CutSceneFlags.Image3Seen = true;
                Debug.Log("✅ Image3Seen is now TRUE.");
                break;
            case 4:
                CutSceneFlags.Image4Seen = true;
                Debug.Log("✅ Image4Seen is now TRUE.");
                break;
            default:
                Debug.LogWarning("⚠️ Invalid tablet ID assigned.");
                break;
        }
    }

    IEnumerator MoveTablet()
    {
        isMoving = true;
        Debug.Log("🛫 Starting tablet movement...");

        Vector3 originalPos = tabletObject.position;
        Quaternion originalRot = tabletObject.rotation;

        Vector3 endPos = targetPosition.position;
        Quaternion endRot = Quaternion.Euler(0f, 180f, 180f);

        float t = 0f;

        if (audioSource != null)
        {
            audioSource.Play();
            Debug.Log("🔊 Played audio clip.");
        }

        while (t < 1f)
        {
            t += Time.deltaTime * moveSpeed;
            tabletObject.position = Vector3.Lerp(originalPos, endPos, t);
            tabletObject.rotation = Quaternion.Slerp(originalRot, endRot, t);
            yield return null;
        }

        Debug.Log("✅ Tablet reached final position.");
        yield return new WaitForSeconds(2f);
        Debug.Log("⏳ 3 seconds passed. Returning tablet...");

        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * moveSpeed;
            tabletObject.position = Vector3.Lerp(endPos, originalPos, t);
            tabletObject.rotation = Quaternion.Slerp(endRot, originalRot, t);
            yield return null;
        }

        Debug.Log("🏁 Tablet returned to original position.");
        isMoving = false;
    }

    void Update()
    {
        if (faceCamera && isMoving)
        {
            Vector3 lookDir = Camera.main.transform.position - tabletObject.position;
            lookDir.y = 0;
            Debug.Log("🔄 Rotating tablet to face player.");
        }
    }
}
