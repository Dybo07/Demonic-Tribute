using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramovement : MonoBehaviour
{
    public float verticalLookRotation;
    public float mouseSpeed;
    public Transform cameraHolder;
    // Start is called before the first frame update
    void Start()
    {
        mouseSpeed = 5;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(Input.GetAxisRaw("Mouse X") * mouseSpeed * Vector3.up);
       verticalLookRotation -= Input.GetAxisRaw("Mouse Y") * mouseSpeed;
       verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
       cameraHolder.localEulerAngles = new Vector3(verticalLookRotation, 0, 0);

    }
}
