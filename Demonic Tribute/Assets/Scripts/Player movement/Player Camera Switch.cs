using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.Rendering;
using Cinemachine;

public class PlayerCameraSwitch : MonoBehaviour
{
    public GameObject camFP;
    public GameObject camTP;
    public GameObject player;
    public Transform playerObj;
    public GameObject cineMach;

    public bool cameraSwitch;

    public bool inventoryOpen;

    // Start is called before the first frame update
    void Start()
    {
        camFP.SetActive(false);
        camTP.SetActive(true);
        cameraSwitch = false;

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

            player.GetComponent<ThirdPersoonCameraRotation>().enabled = false;
            player.GetComponent<FirstPersonCamera>().enabled = true;
            player.GetComponent<Firstpersonmovement>().enabled = true;

            player.GetComponent<Transform>().rotation = playerObj.rotation;
            playerObj.rotation = player.GetComponent<Transform>().rotation;

            cameraSwitch = true;
        }
        else if (Input.GetButtonDown("CamSwitch") && cameraSwitch == true && inventoryOpen == false)
        {
            camFP.SetActive(false);
            camTP.SetActive(true);

            player.GetComponent<ThirdPersoonCameraRotation>().enabled = true;
            player.GetComponent<FirstPersonCamera>().enabled = false;
            player.GetComponent<Firstpersonmovement>().enabled = false;

            player.GetComponent<Transform>().rotation = playerObj.rotation;
            playerObj.rotation = player.GetComponent<Transform>().rotation;

            cameraSwitch = false;
        }

        //Inventory inputs
        if (Input.GetButtonDown("tab") && inventoryOpen == false)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            player.GetComponent<ThirdPersoonCameraRotation>().enabled = false;
            player.GetComponent<FirstPersonCamera>().enabled = false;
            player.GetComponent<Firstpersonmovement>().enabled = false;
            cineMach.GetComponent<CinemachineFreeLook>().enabled = false;

            inventoryOpen = true;
        }
        else if(Input.GetButtonDown("tab") && inventoryOpen == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            player.GetComponent<ThirdPersoonCameraRotation>().enabled = true;
            player.GetComponent<FirstPersonCamera>().enabled = true;
            player.GetComponent<Firstpersonmovement>().enabled = true;
            cineMach.GetComponent<CinemachineFreeLook>().enabled = true;

            inventoryOpen = false;
        }
    }
}
