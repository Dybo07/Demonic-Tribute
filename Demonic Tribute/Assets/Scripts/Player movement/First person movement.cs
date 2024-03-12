using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firstpersonmovement : MonoBehaviour
{
    [Header("Movement variables")]
    public float vert;
    public float hori;
    public Vector3 dir;
    public float speed;
    
    public Rigidbody rb;

    public float jumpForce;
    public bool grounded;

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
        if (grounded == true && Input.GetButton("Jump"))
        {
            rb.AddForce(transform.up * jumpForce);
            grounded = false;
        }
    }

    private void OnCollisionStay(Collision beanCollision)
    {

        if(beanCollision.gameObject.CompareTag ("Ground"))
        {
            grounded = true;
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
        
    }
}
