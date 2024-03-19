using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveDataJSON : MonoBehaviour
{
    private PlayerData playerData;
    public DayCounter dayCounter;

    void Start()
    {
        playerData = LoadData();
    }
    public void SaveData()
    {
        playerData.day = dayCounter.day;
        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        using (StreamWriter writer1 = new StreamWriter(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
        {
            writer1.Write(json);
        }
    }
    public PlayerData LoadData()
    {
        string json = string.Empty;

        if (File.Exists(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
        {
            using (StreamReader reader1 = new StreamReader(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
            {
                json = reader1.ReadToEnd();
            }
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            dayCounter.day = data.day;
            return data;
        }
        else
        {
            PlayerData data = new PlayerData();
            return data;
        }
       
    }

} 
