//John Bowditch 2023.09.26 - Third Person Controller based on Rigid Bodies

//Using denotes Libraries that we're referencing
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ThirdPersonController : MonoBehaviour
{

    private string[] phrases;

    //Variable Declarations

    // Input Variables
    private Vector2 move_input;

    //Camera Variables
    public new Transform camera;

    // Player Variables 
    public new Rigidbody rigidbody;
    public Transform player;
    public Transform player_model;
    public Transform orientation;
    public float move_force; //Force applied to player
    public float rotation_speed; //How fast model rotates
    private Vector3 direction;
    public float jump_force = 500f;

    //Raycast Variables
    private float ray_length = 2.5f;

    public bool IsJumping()
    {
        // Check if the player is currently jumping based on the vertical velocity
        return Mathf.Abs(rigidbody.velocity.y) > 0.1f;
    }


    public bool IsMoving()
    {
        // Check if the player is currently moving based on the input direction
        return move_input.magnitude > 0.1f;
    }


    // Start is called before the first frame update
    void Start()
    {
        phrases = new string[7]; //Decalre length of the array.
        phrases[0] = "YOU SUCK";
        phrases[1] = "PLAY SOMETHING EASIER";
        phrases[2] = "A";
        phrases[3] = "B";
        phrases[4] = "C";
        phrases[5] = "D";
        phrases[6] = "E";

        int randnum = Random.Range(0, phrases.Length - 1);
        print(phrases[randnum]);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayerModel();
        Debug.DrawRay(transform.position, Vector3.down * ray_length, Color.blue);

    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    public void GetMovementInput(InputAction.CallbackContext context)
    {

        move_input = context.ReadValue<Vector2>();
        Debug.Log(move_input);

    }

    public void GetJumpInput(InputAction.CallbackContext context)
    {
        //When button or key is pressed, execute
        if(context.phase == InputActionPhase.Started)
        {
            Jump();
        }

    }

    public void RotatePlayerModel()
    {
        //What direction to face

        var cam_position = new Vector3(camera.position.x, player.position.y, camera.position.z); 
        Vector3 view_direction = player.position - cam_position;

        orientation.forward = view_direction;

        //Set the direction
        direction = orientation.right * move_input.x + orientation.forward * move_input.y;
        direction = direction.normalized;

        //Keyboard input

        if(move_input != Vector2.zero)
        {
            //Creates a new rotation that we want to player_model to look at
            Quaternion new_rotation = Quaternion.LookRotation(direction, Vector3.up);

            //Calcuated rotation, now we want the playe_model to move towards that rotation
            player_model.rotation = Quaternion.Slerp(player_model.rotation, new_rotation, rotation_speed * Time.deltaTime);
        }
    }

    public void MovePlayer()
    {
        rigidbody.AddForce(direction * move_force, ForceMode.Force);

    }

    public void Jump()
    {
        if (IsOnGround())
        {

            rigidbody.AddForce(Vector3.up * jump_force);
        }
    }

   public bool IsOnGround()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        return Physics.Raycast(ray, ray_length);
    }
}
