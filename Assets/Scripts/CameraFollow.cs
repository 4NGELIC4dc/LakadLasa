using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Drag your player GameObject here
    public Transform leftBoundary; // Drag LeftBoundary GameObject here
    public Transform rightBoundary; // Drag RightBoundary GameObject here

    private float cameraHalfWidth;

    private void Start()
    {
        // Calculate half the width of the camera view in world units
        cameraHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    void LateUpdate()
    {
        if (player == null || leftBoundary == null || rightBoundary == null) return;

        // Target position to follow player
        float targetX = player.position.x;

        // Get boundary limits adjusted by camera width
        float minX = leftBoundary.position.x + cameraHalfWidth;
        float maxX = rightBoundary.position.x - cameraHalfWidth;

        // Clamp camera X position between boundaries
        float clampedX = Mathf.Clamp(targetX, minX, maxX);

        // Apply clamped position while keeping original Y and Z
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
