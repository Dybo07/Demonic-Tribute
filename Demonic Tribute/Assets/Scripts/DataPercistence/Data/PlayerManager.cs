using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public int dayCounter;
    public float scoreCounter;
    public Vector3 posPlayer;
    public Transform player;
    public void Start()
    {
        
        if (instance != null && instance == this) 
        {
            instance = this;
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(AutoSave());
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("days", dayCounter);
        PlayerPrefs.SetFloat("score", scoreCounter);

        posPlayer = player.position;
        PlayerPrefs.SetFloat("posX", posPlayer.x);
        PlayerPrefs.SetFloat("posY", posPlayer.y);
        PlayerPrefs.SetFloat("posZ", posPlayer.z);
    }

    public void  SaveScore(int offerAmount, int offerCount)
    {
        PlayerPrefs.SetInt("offerAmount", offerAmount);
        PlayerPrefs.SetInt("offerCount", offerCount);
    }
    public void LoadData()
    {
        dayCounter = PlayerPrefs.GetInt("days");
        scoreCounter = PlayerPrefs.GetFloat("score");
        player.position = new Vector3((PlayerPrefs.GetFloat("posX")), (PlayerPrefs.GetFloat("posY")), (PlayerPrefs.GetFloat("posZ")));
        ScoreManager.instance.offerAmount = PlayerPrefs.GetInt("offerAmount");
        ScoreManager.instance.offerItem.offerCount = PlayerPrefs.GetInt("offerCount");
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }
    public IEnumerator AutoSave()
    {
        yield return new WaitForSeconds(30);

        SaveData();
        StartCoroutine(AutoSave());
    }

}
