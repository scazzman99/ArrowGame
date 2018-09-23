using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour {

    public CharacterController player;
    public float speed;
    public float jumpSpeed;
    public float grav = 20f;
    public Vector3 direction = Vector3.zero;
    public float clampMin, clampMax, sensX, sensY, rotY;
    public Camera mainCam;
    
	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        CamMove();
	}

    private void Movement()
    {
        if (player.isGrounded)
        {
            float inputX = Input.GetAxis("Horizontal") * speed;
            float inputY = Input.GetAxis("Vertical") * speed;
            direction = new Vector3(inputX, 0, inputY);
            direction = transform.TransformDirection(direction);
        }
        direction.y -= grav * Time.deltaTime;
        player.Move(direction * Time.deltaTime);
    }

    private void CamMove()
    {
        rotY += Input.GetAxis("Mouse Y") * sensY;
        rotY = Mathf.Clamp(rotY, clampMin, clampMax);
        mainCam.transform.localEulerAngles = new Vector3(-rotY, 0f, 0f);
        player.transform.Rotate(0f, Input.GetAxis("Mouse X") * sensX, 0f);
    }
}
