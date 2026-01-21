
using UnityEngine;
using UnityEngine.InputSystem; // New Input System

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity = 50f; // final value used at the end of the episode
    public Transform cam;

    private float xRotation = 0f;
    private Vector2 lookInput;

    void Start()
    {
        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Called by Player Input (Send Messages) when Look value changes
    void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    void Update()
    {
        HandleMouseLook();
    }

    void HandleMouseLook()
    {
        // Convert input to per-second rotation using sensitivity and deltaTime
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        // Vertical look (camera) — clamp to prevent over-rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Horizontal look (player body)
        transform.Rotate(Vector3.up * mouseX);
    }
}
