using UnityEngine;

public class PathDrawer : MonoBehaviour
{
    public GameObject pointPrefab; // assign your glowing prefab in Inspector
    public Transform startPoint;   // set to your player or start position
    public Transform targetPoint;  // set to the destination (e.g., a door)

    public int numberOfPoints = 10; // how many dots you want

    public void DrawPath()
    {
        // Clean up old points if needed
        foreach (var oldPoint in GameObject.FindGameObjectsWithTag("PathPoint"))
        {
            Destroy(oldPoint);
        }

        // Draw new direction points
        Vector3 direction = (targetPoint.position - startPoint.position).normalized;
        float totalDistance = Vector3.Distance(startPoint.position, targetPoint.position);
        float spacing = totalDistance / numberOfPoints;

        for (int i = 1; i <= numberOfPoints; i++)
        {
            Vector3 pointPosition = startPoint.position + direction * spacing * i;
            GameObject point = Instantiate(pointPrefab, pointPosition, Quaternion.identity);
            point.tag = "PathPoint"; // Optional: so we can clean it later
        }
    }
}
