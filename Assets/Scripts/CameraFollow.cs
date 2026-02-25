using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;         // Drag the player here in the Inspector
    public float distance = 5f;
    public float height = 2f;
    public float smoothSpeed = 10f;

    void LateUpdate()
    {
        // Desired position is directly behind and above the target
        Vector3 desiredPosition = target.position - target.forward * distance + Vector3.up * height;

        // Smoothly move toward the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Always look at the target
        transform.LookAt(target.position + Vector3.up);
    }
}
