using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersoonCameraRotation : MonoBehaviour
{
    public Transform orientation;
    public Transform player;
    public Transform playerObj;

    public float rotationSpeed;

    public float hori;
    public float vert;
    public Vector3 dir;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 5;

        speed = 5;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        hori = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        transform.Translate(dir * speed * Time.deltaTime);
        dir = orientation.forward * vert + orientation.right * hori;

        if (dir != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, dir.normalized, Time.deltaTime * rotationSpeed);

        }

    }
}
