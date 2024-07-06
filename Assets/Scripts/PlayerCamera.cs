
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public float rotSpeed = 300f;

    private float pitch = 1.0f;

    public Transform player;

    void Start(){

        // Cursor.lockState = CursorLockMode.Locked;
    }
    
    // Update is called once per frame
    void Update(){
        CameraControls();
    }

    private void CameraControls(){
        float yaw = rotSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
        float pitchAxis =  rotSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;
        pitch -= pitchAxis;
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
        player.Rotate(Vector3.up * yaw);
    }
}
