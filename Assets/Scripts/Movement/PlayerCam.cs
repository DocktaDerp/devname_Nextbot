using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;
    public Transform cameraPosition;

    private bool wantCrouch = false;
    public SphereCollider head;    
    public PlayerController pc;

    float xRotation;
    float yRotation;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameObject.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        InputCollection();
        MoveCam();
        HandleCrouch();

    }

    private void InputCollection()
    {
        // get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        wantCrouch = Input.GetKeyDown(pc.crouchKey);

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }

    private void MoveCam()
    {
        // rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); //rotate cam
        orientation.rotation = Quaternion.Euler(0, yRotation, 0); //rotate player
        transform.position = cameraPosition.position;
    }

    private void HandleCrouch()
    {
        head.isTrigger = wantCrouch;
    }
}
