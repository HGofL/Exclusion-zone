using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class animationStateController : MonoBehaviour
{

    private Animator animator;
    int isRunningHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool("isRunningHash");
        bool forwardPressed = Input.GetKey("w");
        //if player presses W key...
        if (isRunning && forwardPressed)
        {
            //then set the isWalking boolean to be true
            animator.SetBool("isRunningHash", true);
         }

         //if player is not pressing the W key...
        if (isRunning && !forwardPressed)
        {
            //then set the isWalking boolean to be false
            animator.SetBool("isRunningHash", false);
         }
    }
}
