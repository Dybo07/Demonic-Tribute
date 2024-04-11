using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersoonCameraRotation : MonoBehaviour
{
    public Rigidbody rb;
    public Transform orientation;
    public Transform tPCAM;
    public Transform playerObj;

    public float rotationSpeed;

    public float hori;
    public float vert;
    public Vector3 dir;
    public Vector3 dirMov;
    public float speed;

    [Header("Jump variables")]
    public float jumpForce;
    public bool grounded;

    [Header("Dash variables")]
    public float dashForce;
    public bool dashBool = false;
    public float dashDelay;

    [Header("Animation")]
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 5;

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
        Vector3 viewDir = transform.position - new Vector3(tPCAM.position.x, transform.position.y, tPCAM.position.z);
        orientation.forward = viewDir.normalized;

        hori = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        dir = orientation.forward * vert + orientation.right * hori;
        
        transform.Translate(dir * speed * Time.deltaTime);

        if (dir != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if (dir != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, dir.normalized, Time.deltaTime * rotationSpeed);

        }

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
            rb.AddForce(playerObj.forward * dashForce);
            StartCoroutine(DashCoolDown());
        }

        //Jump script
        if (grounded == true && Input.GetButton("Jump"))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Force);
            grounded = false;
        }

    }
    private void OnCollisionStay(Collision beanCollision)
    {

        if (beanCollision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}
