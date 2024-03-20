using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnscript : MonoBehaviour
{
    [Header("Number of items to spawn")]
    public int numberOfItems;

    [Header("items")]
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public GameObject item5;

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
        spawnCollider = GetComponent<Collider>();

        for (int i = 0; i < numberOfItems; i++)
        {
            spawnPoint.x = Random.Range(spawnCollider.bounds.min.x, spawnCollider.bounds.max.x);
            spawnPoint.z = Random.Range(spawnCollider.bounds.min.z, spawnCollider.bounds.max.z);
            spawnPoint = new Vector3(spawnPoint.x, 0, spawnPoint.z);

            spawnPoint.y = terrain.SampleHeight(spawnPoint);

            randomYRot = Random.Range(1, 361);
            randomQuaternion = Quaternion.Euler(0, randomYRot, 0);

            randomNum = Random.Range(1, 6);

            switch (randomNum)
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
}




