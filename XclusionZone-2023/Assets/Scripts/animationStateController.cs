using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class animationStateController : MonoBehaviour
{
    private Animator animator;
    private ThirdPersonController thirdPersonController;
    private Rigidbody rb;

    // Animation states
    const string IdleState = "Idle";
    const string RunState = "Run";
    const string JumpState = "Jump";
    const string FallState = "Fall";

    // Parameters
    int isRunningHash;
    int isJumpingHash;
    int isFallingHash;

    // Ground check parameters
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        rb = GetComponent<Rigidbody>();

        // Get hash of parameters for faster access
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
        isFallingHash = Animator.StringToHash("isFalling");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Check if the player is grounded
        bool isGrounded = thirdPersonController.IsOnGround();

        // Handle movement and jump from ThirdPersonController
        thirdPersonController.MovePlayer();

        // Clamp maximum speed
        float maxSpeed = 10f; // Adjust this value as needed
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        
        // Set animator parameters based on input and ground status
        animator.SetBool(isRunningHash, thirdPersonController.isMoving());

        // Check if the player wants to jump and is grounded
        if (isGrounded && JumpInputDetected())
        {
            thirdPersonController.Jump(); // Execute jump logic
            animator.SetBool(isJumpingHash, true); // Set jump animation
        }
        else
        {
            animator.SetBool(isJumpingHash, false); // Set jump animation to false if not jumping
        }

        // Set falling animation
        bool isFalling = !isGrounded && rb.velocity.y < 0;
        animator.SetBool(isFallingHash, isFalling);
    }

    // Method to detect jump input
    bool JumpInputDetected()
    {
        // You can change this input condition based on your control scheme
        return Keyboard.current.spaceKey.wasPressedThisFrame;
    }
}
