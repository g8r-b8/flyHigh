using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player_Controller : MonoBehaviour
{

    public bool keyboard_enabled = true;
    public float gravity = -9.81f;

    public CharacterController controller;
    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;

    [SerializeField] float jumpForce = 10.0f;
    [SerializeField] float movementSpeed = 15f;


    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update(){
        if (keyboard_enabled){
            KeyboardControls();
        }
        ApplyGroundForce();
        ApplyGravity();
        ApplyVelocity();
    }

    private void ApplyGroundForce(){
        if (IsGrounded()){
            if (!isGrounded){
                velocity.y = 0f;
                isGrounded = true;
            }
            velocity.y -= gravity * Time.deltaTime * Time.deltaTime;
        }else{
            isGrounded = false;
        }

    }

    private void ApplyGravity(){
        velocity.y += gravity * Time.deltaTime * Time.deltaTime;
    }

    private void ApplyVelocity(){
        Debug.Log(velocity);
        controller.Move(velocity);
    }

    private void FlapControlsKeyboard(){
        if (Input.GetButtonDown("Jump")){
            //velocity.y 
            //controller.Move(;
            velocity += new Vector3(0f, jumpForce, 0f) * Time.deltaTime;
        }
    }

    private bool IsGrounded(){
        //if (velocity.y == 0){return true;}else{return false;}
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    private void MovementControlsKeyboard(){
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        Vector3 move = transform.right * x + transform.forward * z;
        //velocity += move * movementSpeed * Time.deltaTime;
        controller.Move(move * movementSpeed * Time.deltaTime);
    }

    private void KeyboardControls(){
        FlapControlsKeyboard();
        MovementControlsKeyboard();
    }
}
