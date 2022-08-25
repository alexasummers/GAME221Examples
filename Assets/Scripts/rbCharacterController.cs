using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//https://www.youtube.com/watch?v=1LtePgzeqjQ

public class rbCharacterController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float sensitivity;
    public float maxForce;
    private Vector2 move;
    private Vector2 look;
    private float lookRotation;
    public Camera main_camera;

    public void OnMove(InputAction.CallbackContext context) //input system for movement
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context) //input system for rotation
    {
        look = context.ReadValue<Vector2>();
    }

    private void FixedUpdate() //use fixed because we have a rb that is physics-based
    {
        Vector3 currentVelocity = rb.velocity; //find target velocity
        Vector3 targetVelocity = new Vector3(move.x, 0, move.y); //take input and change it into a vector to move character
        targetVelocity *= speed;

        targetVelocity = transform.TransformDirection(targetVelocity); //align direction with player so we move in right direction

        Vector3 velocityChange = (targetVelocity - currentVelocity); //calculate amount of forces to apply to player

        Vector3.ClampMagnitude(velocityChange, maxForce); //limit amount of force on player

        rb.AddForce(velocityChange, ForceMode.VelocityChange); //add velocity change to player
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //lock mouse in center of screen
    }

    void LateUpdate()                                                                                         //move camera after rest of scene has been updated
    {
        transform.Rotate(Vector3.up * look.x * sensitivity);                                                                         //turn player on up axis

        lookRotation +=(-look.y * sensitivity);                                                                                               //player looks up and down
        lookRotation = Mathf.Clamp(lookRotation, -90, 90);                                                              //player up and down looking stops at halfway up and down
        main_camera.transform.eulerAngles = new Vector3(lookRotation, 
        main_camera.transform.eulerAngles.y, main_camera.transform.eulerAngles.z);                          //rotate the camera (in world space)
    }

}
