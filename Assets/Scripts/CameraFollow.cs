using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;            // Player to follow
    public float smoothSpeed = 0.125f;  // Camera smoothing
    public float minX = 0f;             // Left boundary
    public float maxX = 4000f;          // Right boundary
    public float fixedY = 692f;         // Lock Y to this value

    private float offsetX;

    void Start()
    {
        if (target != null)
        {
            // Use current camera position to calculate offsetX (respects manual placement)
            offsetX = transform.position.x - target.position.x;
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            float desiredX = target.position.x + offsetX;

            // Clamp X to stay within your level bounds
            float clampedX = Mathf.Clamp(desiredX, minX, maxX);

            Vector3 targetPos = new Vector3(clampedX, fixedY, transform.position.z);
            Vector3 smoothed = Vector3.Lerp(transform.position, targetPos, smoothSpeed);

            transform.position = smoothed;
        }
    }
}
