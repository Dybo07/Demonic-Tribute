using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnscript : MonoBehaviour
{
    public static ItemSpawnscript instance;

    [Header("Number of items to spawn")]
    public int numberOfItems;

    [Header("items")]
    public GameObject[] items;

    [Header("Other variables")]
    public Terrain terrain;
    public Collider spawnCollider;
    public Vector3 spawnPoint;

    public int randomNum;
    public Quaternion randomQuaternion;
    public float randomYRot;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null) 
        {  
            instance = this; 
        }

        spawnCollider = GetComponent<Collider>();

        for (int i = 0; i < numberOfItems; i++)
        {
            spawnPoint.x = Random.Range(spawnCollider.bounds.min.x, spawnCollider.bounds.max.x);
            spawnPoint.z = Random.Range(spawnCollider.bounds.min.z, spawnCollider.bounds.max.z);
            spawnPoint = new Vector3(spawnPoint.x, 0, spawnPoint.z);

            spawnPoint.y = terrain.SampleHeight(spawnPoint);

            randomYRot = Random.Range(1, 361);
            randomQuaternion = Quaternion.Euler(0, randomYRot, 0);

            randomNum = Random.Range(0, 5);

            Instantiate(items[randomNum], spawnPoint, randomQuaternion);
        }
    }
}




