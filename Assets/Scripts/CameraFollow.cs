using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float smoothSpeed = 10f;

    // NEW: Mouse orbit controls
    public float mouseSensitivity = 3f;
    public float minPitch = -20f;
    public float maxPitch = 60f;

    float yaw;    // Horizontal angle
    float pitch;  // Vertical angle

    void LateUpdate()
    {
        // NEW: Read mouse input to rotate the orbit angles
        yaw   += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch  = Mathf.Clamp(pitch, minPitch, maxPitch);

        // NEW: Convert angles to a position on the sphere around the target
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 offset = rotation * new Vector3(0f, 0f, -distance);
        Vector3 desiredPosition = target.position + offset;

        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(target.position);
    }
}
