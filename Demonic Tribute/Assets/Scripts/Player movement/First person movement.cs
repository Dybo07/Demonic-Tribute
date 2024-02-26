using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firstpersonmovement : MonoBehaviour
{
    public float vert;
    public float hori;
    public Vector3 dir;
    public float speed;
    
    public Rigidbody rb;
    public int jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;

        jumpForce = 10;

    }

    // Update is called once per frame
    void Update()
    {
        //Movement script
        hori = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        dir.x = hori;
        dir.z = vert;
        transform.Translate(dir * speed * Time.deltaTime);

        if (Input.GetButton("Sprint"))
        {
            speed = 10;
        }
        else
        {
            speed = 5;
        }

        //Jump script
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce);

        }

    }
}
