using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float jumpTime = 0.3f;

    [Header("Sound Settings")]
    [SerializeField] private AudioSource audioSource;   // Reference to AudioSource
    [SerializeField] private AudioClip jumpSound;       // Jump sound clip

    private bool isGrounded = false;
    private bool isJumping = false;
    private float jumpTimer;

    private void Update()
    {
        // Check if grounded
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);

        // KEYBOARD JUMP
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            StartJump();
        }

        // TOUCH JUMP (for mobile & WebGL mobile browser)
        if (isGrounded && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                StartJump();
            }
        }

        // Hold jump for variable height (works for both touch & keyboard)
        if (isJumping && (Input.GetButton("Jump") || IsTouchHeld()))
        {
            if (jumpTimer < jumpTime)
            {
                rb.linearVelocity = Vector2.up * jumpForce;
                jumpTimer += Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        // Stop jump when releasing
        if (Input.GetButtonUp("Jump") || TouchReleased())
        {
            isJumping = false;
            jumpTimer = 0;
        }
    }

    private void StartJump()
    {
        isJumping = true;
        jumpTimer = 0;
        rb.linearVelocity = Vector2.up * jumpForce;

        // Play jump sound if available
        if (audioSource != null && jumpSound != null)
            audioSource.PlayOneShot(jumpSound);
    }

    // Detect if touch is still being held
    private bool IsTouchHeld()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            return touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved;
        }
        return false;
    }

    // Detect if touch released
    private bool TouchReleased()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            return touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled;
        }
        return false;
    }
}
