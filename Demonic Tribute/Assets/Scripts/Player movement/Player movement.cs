using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float vert;
    public float hori;
    public Vector3 dir;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;

    }

    // Update is called once per frame
    void Update()
    {
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

    }
}
