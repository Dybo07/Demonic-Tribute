using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    
    private float hor;
    private float vert;
    private Vector3 dir;
    public float speed;
    private bool onGround;
    public Rigidbody rb;
    public float jumpVelocity;

    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();

        speed = 10;
        jumpVelocity = 5;
    }
    void Update()
    {
        //player movement
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        dir.x = hor;
        dir.z = vert;
       //transform.Translate(dir * speed * Time.deltaTime);
        rb.velocity = dir * speed * Time.deltaTime;

        //jump
        if (Input.GetButton("Jump") && onGround)
        {
            rb.velocity = new Vector3(0, jumpVelocity, 0);
            onGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
}

