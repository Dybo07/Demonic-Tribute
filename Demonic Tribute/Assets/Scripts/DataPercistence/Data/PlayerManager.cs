using System.Collections;
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

    public void SaveData()
    {
        PlayerPrefs.SetInt("days", dayCounter);
        PlayerPrefs.SetFloat("score", scoreCounter);

        pos = player.position;
        PlayerPrefs.SetFloat("posX", pos.x);
        PlayerPrefs.SetFloat("posY", pos.y);
        PlayerPrefs.SetFloat("posZ", pos.z);
    }
    public void LoadData()
    {
        dayCounter = PlayerPrefs.GetInt("days");
        scoreCounter = PlayerPrefs.GetFloat("score");
        player.position = new Vector3((PlayerPrefs.GetFloat("posX")), (PlayerPrefs.GetFloat("posY")), (PlayerPrefs.GetFloat("posZ")));

    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }
    public IEnumerator AutoSave()
    {
        yield return new WaitForSeconds(30);

        SaveData();
    }

}
