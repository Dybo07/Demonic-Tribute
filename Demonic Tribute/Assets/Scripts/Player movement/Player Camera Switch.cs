using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.Rendering;

public class PlayerCameraSwitch : MonoBehaviour
{
    public GameObject camFP;
    public GameObject camTP;
    public GameObject player;
    public bool cameraSwitch;

    public bool inventoryOpen;

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
        if (Input.GetButtonDown("CamSwitch") && cameraSwitch == false && inventoryOpen == false)
        {
            camFP.SetActive(true);
            camTP.SetActive(false);
            cameraSwitch = !cameraSwitch;

            //GetComponent<ThirdPersoonCameraRotation>().enabled = false;
            player.GetComponent<FirstPersonCamera>().enabled = true;
            player.GetComponent<Firstpersonmovement>().enabled = true;
        }
        else if (Input.GetButtonDown("CamSwitch") && cameraSwitch == true && inventoryOpen == false)
        {
            camFP.SetActive(false);
            camTP.SetActive(true);
            cameraSwitch = !cameraSwitch;

            //GetComponent<ThirdPersoonCameraRotation>().enabled = true;
            player.GetComponent<FirstPersonCamera>().enabled = false;
            player.GetComponent<Firstpersonmovement>().enabled = false;
        }

        //Inventory inputs
        if (Input.GetButtonDown("tab") && inventoryOpen == false)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            inventoryOpen = !inventoryOpen;
           // GetComponent<ThirdPersoonCameraRotation>().enabled = false;
            player.GetComponent<FirstPersonCamera>().enabled = false;
            player.GetComponent<Firstpersonmovement>().enabled = false;
        }
        else if(Input.GetButtonDown("tab") && inventoryOpen == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            inventoryOpen = !inventoryOpen;

           // GetComponent<ThirdPersoonCameraRotation>().enabled = true;
            player.GetComponent<FirstPersonCamera>().enabled = true;
            player.GetComponent<Firstpersonmovement>().enabled = true;
        }
    }
}
