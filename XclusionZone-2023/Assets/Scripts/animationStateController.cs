using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class animationStateController : MonoBehaviour
{

    private Animator animator;
    private ThirdPersonController thirdPersonController;

    // Animation states
    const string IdleState = "Idle";
    const string RunState = "Run";
    const string JumpState = "Jump";

    // Parameters
    int isRunningHash;
    int isJumpingHash;

    // Speed and jump parameters
    public float runSpeed = 5f;
    public float jumpForce = 8f;

    // Ground check parameters
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        thirdPersonController = GetComponent<ThirdPersonController>();

        // Get hash of parameters for faster access
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("IsJumping");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is grounded
        bool isGrounded = thirdPersonController.IsOnGround();

        // Handle movement and jump from ThirdPersonController
        thirdPersonController.MovePlayer();
        thirdPersonController.Jump();
        
         // Set animator parameters based on input and ground status
        animator.SetBool(isRunningHash, thirdPersonController.IsMoving());
        animator.SetBool(isJumpingHash, !isGrounded && thirdPersonController.IsJumping());
    }
}
