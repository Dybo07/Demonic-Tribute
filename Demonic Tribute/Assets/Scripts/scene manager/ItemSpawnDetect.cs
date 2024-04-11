using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnDetect : MonoBehaviour
{
    public bool cantSpawn;

    private void OnCollisionEnter(Collision itemCollision)
    {
        if (itemCollision.gameObject.CompareTag("Obstacle"))
        {
            cantSpawn = true;
        }
        
    }
}
