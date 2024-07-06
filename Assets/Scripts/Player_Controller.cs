using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]

public class Player_Controller : MonoBehaviour
{

    public bool keyboard_enabled = true;

    private CapsuleCollider _collider;
    private Rigidbody _body;
    private CharacterController _controller;

    [SerializeField] float jumpForce = 500.0f;
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] GameObject _camera;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<CapsuleCollider>();
        _body = GetComponent<Rigidbody>();
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update(){
        if (keyboard_enabled){
            KeyboardControls();
        }
    }

    private void FlapControlsKeyboard(){
        if (Input.GetButtonDown("Jump")){
            _body.AddForce(new Vector2(0f, jumpForce));
        }
    }

    private bool IsGrounded(){
        if (_body.velocity.y == 0){return true;}else{return false;}
    }

    private void MovementControlsKeyboard(){
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _controller.Move(input * movementSpeed * Time.deltaTime);
        if (input != Vector3.zero){
            gameObject.transform.forward = input; 
        }
    }

    private void KeyboardControls(){
        FlapControlsKeyboard();
        MovementControlsKeyboard();
    }
}
