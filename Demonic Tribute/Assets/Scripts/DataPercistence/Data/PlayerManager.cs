using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
    public static PlayerManager instance;
    public int dayCounter;
    public float scoreCounter;
    public Vector3 pos;
    public Transform player;
    public void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            LoadData();
        }
    }

    public void LoadData()
    {
        dayCounter = PlayerPrefs.GetInt("days");
        scoreCounter = PlayerPrefs.GetFloat("score");
        pos = new Vector3((PlayerPrefs.GetFloat("posY")),(PlayerPrefs.GetFloat("posX")), (PlayerPrefs.GetFloat("posZ")));

    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("days", dayCounter);
        PlayerPrefs.SetFloat("score", scoreCounter);

        pos = player.position;
        PlayerPrefs.SetFloat("posY", pos.y);
        PlayerPrefs.SetFloat("posX", pos.x);
        PlayerPrefs.SetFloat("posZ", pos.z);
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }
    public IEnumerator AutoSave()
    {
        yield return new WaitForSeconds(5);

        SaveData();
    }

}
