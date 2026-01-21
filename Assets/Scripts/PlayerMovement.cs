using UnityEngine;
using UnityEngine.InputSystem; // New Input System

public class PlayerMovement : MonoBehaviour
{
    // Movement settings
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    // Ground check
    public Transform groundCheck;     // place at the player's feet
    public float groundDistance = 0.4f;  //sphere radius
    public LayerMask groundMask;      // set to the "Ground" layer

    // Internals
    private Rigidbody rb;
    private Vector2 moveInput;
    private bool isGrounded;

    // As shown in the episode, he adds a PlayerInput field and instantiates it
    private PlayerInput playerInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = new PlayerInput(); // mirrors the instructor
        // Freeze X and Z rotation in the Inspector (as done in the video).
    }

    void Update()
    {
        CheckGround();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    // Called by Player Input (Send Messages) when Jump is performed
    void OnJump()
    {
        if (isGrounded)
        {
            // Upward impulse
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        }
    }

    // Called by Player Input (Send Messages) when Movement value changes
    void OnMovement(InputValue value)
    {
        // Read WASD composite as Vector2: x = A/D, y = W/S
        moveInput = value.Get<Vector2>();
    }

    // Apply horizontal linear velocity based on transform.right/forward
    void MovePlayer()
    {
        Vector3 direction =
            (transform.right * moveInput.x) +
            (transform.forward * moveInput.y);

        direction = direction.normalized;

        // Unity 6 API: use linearVelocity (renamed from velocity)
        rb.linearVelocity = new Vector3(
            direction.x * moveSpeed,
            rb.linearVelocity.y,          // preserve vertical motion (gravity / jump)
            direction.z * moveSpeed
        );
    }

    // Ground detection using an invisible sphere at the feet
    void CheckGround()
    {
        if (groundCheck == null)
        {
            isGrounded = false;
            return;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);
    }
}
