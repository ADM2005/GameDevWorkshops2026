using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float smoothSpeed = 10f;
    public float mouseSensitivity = 3f;
    public float minPitch = -20f;
    public float maxPitch = 60f;
    public LayerMask collisionMask;

    Camera cam;
    float yaw;
    float pitch;

    // The half-extents of the box derived from the camera's near clip plane
    Vector3 CameraHalfExtends
    {
        get
        {
            Vector3 halfExtends;
            halfExtends.y = cam.nearClipPlane * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
            halfExtends.x = halfExtends.y * cam.aspect;
            halfExtends.z = 0f;
            return halfExtends;
        }
    }

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        yaw   += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch  = Mathf.Clamp(pitch, minPitch, maxPitch);

        Quaternion lookRotation  = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 lookDirection    = lookRotation * Vector3.forward;
        Vector3 focusPoint       = target.position;
        Vector3 lookPosition     = focusPoint - lookDirection * distance;

        // BoxCast from focus point toward desired camera position
        if (Physics.BoxCast(
                focusPoint, CameraHalfExtends, -lookDirection, out RaycastHit hit,
                lookRotation, distance, collisionMask
            )) {
            lookPosition = focusPoint - lookDirection * hit.distance;
        }

        transform.position = Vector3.MoveTowards(transform.position, lookPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(focusPoint);
    }
}
