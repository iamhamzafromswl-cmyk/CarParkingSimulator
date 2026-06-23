using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target to Follow")]
    public Transform target;

    [Header("Camera Settings")]
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Default offset behind and above the target
    public float smoothSpeed = 0.125f; // How smoothly the camera follows

    void FixedUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("CameraFollow: Target not assigned.");
            return;
        }

        // Calculate the desired position based on the target's position and the offset
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);

        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Make the camera look at the target
        transform.LookAt(target);
    }
}
