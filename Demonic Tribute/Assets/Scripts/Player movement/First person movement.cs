using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firstpersonmovement : MonoBehaviour
{
    public Rigidbody rb;

    [Header("Movement variables")]
    public float vert;
    public float hori;
    public Vector3 dir;
    public float speed;

    [Header("Jump variables")]
    public float jumpForce;
    public bool grounded;

    [Header("Dash variables")]
    public float dashForce;
    public bool dashBool = false;
    public float dashDelay;

    // Start is called before the first frame update
    void Start()
    {

        speed = 5;

        jumpForce = 100;
        grounded = true;

        dashForce = 400;
        dashDelay = 5;

    }
    public IEnumerator DashCoolDown()
    {
        yield return new WaitForSeconds(dashDelay);
        dashBool = true;
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
        //Dash Script
        if (Input.GetMouseButtonDown(1) && dashBool == true)
        {
            dashBool = false;
            rb.AddForce(transform.forward * dashForce);
            StartCoroutine(DashCoolDown());
        }

        //Jump script
        if (grounded == true && Input.GetButton("Jump"))
        {
            rb.AddForce(transform.up * jumpForce,ForceMode.Force);
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
