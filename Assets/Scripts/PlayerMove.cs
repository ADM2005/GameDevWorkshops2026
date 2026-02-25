using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10f;
    public float acceleration = 5f;
    public float jumpForce = 5f;
    public float turnSpeed = 10f;

    // NEW: Reference to the camera so we can read its orientation
    public Camera cam;

    Rigidbody rb;
    Vector2 input;
    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        // NEW: Build movement direction relative to camera
        Vector3 camForward = cam.transform.forward;
        Vector3 camRight   = cam.transform.right;

        // Flatten to horizontal plane so vertical camera tilt doesn't affect movement
        camForward.y = 0f;
        camRight.y   = 0f;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDir = (camForward * input.y + camRight * input.x);

        Vector3 targetVelocity = moveDir.normalized * speed * moveDir.magnitude;
        velocity = Vector3.MoveTowards(velocity, targetVelocity, acceleration * Time.deltaTime);

        // NEW: Rotate player to face movement direction
        if (moveDir.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
    }

    void OnCollisionEnter(Collision other)
    {
        Vector3 normal = other.contacts[0].normal;
        if (Vector3.Dot(normal, Vector3.up) > 0.5f)
        {
            isGrounded = true;
        }
    }
}