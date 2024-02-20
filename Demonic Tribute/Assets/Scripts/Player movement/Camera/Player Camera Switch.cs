using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.Rendering;

public class PlayerCameraSwitch : MonoBehaviour
{
    public GameObject camFP;
    public GameObject camTP;
    public bool cameraSwitch;

    // Start is called before the first frame update
    void Start()
    {
        camFP.SetActive(true);
        camTP.SetActive(false);
        cameraSwitch = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("CamSwitch") && cameraSwitch == false)
        {
            camFP.SetActive(true);
            camTP.SetActive(false);
            cameraSwitch = true;
        }
        else if (Input.GetButtonDown("CamSwitch") && cameraSwitch == true)
        {
            camFP.SetActive(false);
            camTP.SetActive(true);
            cameraSwitch = false;
        }

    }
}
