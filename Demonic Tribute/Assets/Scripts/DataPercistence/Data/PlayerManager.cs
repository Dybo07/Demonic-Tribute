using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
    public static PlayerManager instance;
    public int dayCounter;
    public int scoreCounter;
    public Vector3 pos;
    public Transform player;
    public void Start()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("days", dayCounter);
        PlayerPrefs.SetInt("score", scoreCounter);

        pos = player.position;
        PlayerPrefs.SetFloat("posX", pos.x);
        PlayerPrefs.SetFloat("posY", pos.y);
        PlayerPrefs.SetFloat("posZ", pos.z);
    }
    public void LoadData()
    {
        DayCounter.instance.day = PlayerPrefs.GetInt("days");
        scoreCounter = PlayerPrefs.GetInt("score");
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
