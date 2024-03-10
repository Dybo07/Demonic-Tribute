using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSens = 100f;
    public float mouseX;
    public float mouseY;
    public float vert;
    public float hor;

    public Vector3 rotDir;
    public Vector3 camRotDir;
    public Vector3 moveDir;

    public GameObject cam;

    public void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        rotDir.y = mouseX * mouseSens * Time.deltaTime;
        camRotDir.x = -mouseY * mouseSens * Time.deltaTime;

        moveDir.z = vert * speed * Time.deltaTime;
        moveDir.x = hor * speed * Time.deltaTime;

        transform.Translate(moveDir);
        transform.Rotate(rotDir);
        cam.transform.Rotate(camRotDir);

    }

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
