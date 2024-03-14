using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnscript : MonoBehaviour
{
    

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public GameObject item5;

    public Vector3 spawnPoint;
    public int randomNum;
    public Quaternion randomQuaternion;
    public float randomY;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = gameObject.transform.position;
        randomY = Random.Range(1,361);
        randomQuaternion = Quaternion.Euler(0,randomY,0);

        randomNum = Random.Range(1, 6);

        switch(randomNum)
        {
            case 5:
                Instantiate(item5, spawnPoint, randomQuaternion);
                break;
            case 4:
                Instantiate(item4, spawnPoint, randomQuaternion);
                break;
            case 3:
                Instantiate(item3, spawnPoint, randomQuaternion);
                break;
            case 2:
                Instantiate(item2, spawnPoint, randomQuaternion);
                break;
            case 1:
                Instantiate(item1, spawnPoint, randomQuaternion);
                break;
            default:
                break;
        }
    }



}
