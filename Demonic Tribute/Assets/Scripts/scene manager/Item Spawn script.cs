using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class ItemSpawnscript : MonoBehaviour
{
    public static ItemSpawnscript instance;

    [Header("Number of items to spawn")]
    public int numberOfItems;
    public int currentNumItems;

    [Header("items")]
    public GameObject[] items;
    public int numGameObjects = 5;
    public GameObject itemHolder;

    [Header("Other variables")]
    public Terrain terrain;
    public Collider spawnCollider;
    public Vector3 spawnPoint;

    public int randomNum;
    public Quaternion randomQuaternion;
    public float randomYRot;

    public bool canInstantiate;

    public bool noSpawn;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null) 
        {  
            instance = this; 
        }
        currentNumItems = 0;

        spawnCollider = GetComponent<Collider>();

        while (currentNumItems < numberOfItems)
        {
            spawnPoint.x = Random.Range(spawnCollider.bounds.min.x, spawnCollider.bounds.max.x);
            spawnPoint.z = Random.Range(spawnCollider.bounds.min.z, spawnCollider.bounds.max.z);
            spawnPoint = new Vector3(spawnPoint.x, 0, spawnPoint.z);

            spawnPoint.y = terrain.SampleHeight(spawnPoint);

            randomYRot = Random.Range(1, 361);
            randomQuaternion = Quaternion.Euler(0, randomYRot, 0);

            randomNum = Random.Range(0, numGameObjects);
            itemHolder = items[randomNum];
            
            Instantiate(itemHolder, spawnPoint, randomQuaternion);

            canInstantiate = true;
            noSpawn = false;
            CheckCollision();
            print("Check");

            if (noSpawn == true)
            {
                canInstantiate = false;
                Destroy(itemHolder);
            }

            if (canInstantiate == true)
            {
                currentNumItems++;
            }
            if (currentNumItems == numberOfItems)
            {
                break;
            }
        }
    }
    public void CheckCollision()
    {
        Collider objectCollider = itemHolder.GetComponent<Collider>();
        if (objectCollider.GetComponent<Collider>().CompareTag("Obstacle"))
        {
            noSpawn = false;
        }
    }
}





