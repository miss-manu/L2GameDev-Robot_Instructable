using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawn : MonoBehaviour
{
    public GameObject[] obj;                        // a public object array for which objects to spawn
    public float spawnMin = 3f;                     // min and max times for another spawn
    public float spawnMax = 2f;

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        float rand = Random.Range(0, 1000);         //get random number
        
        if (rand > 700)                             //if random number is greater than 700 make a bomb
        {
            Instantiate(obj[Random.Range(0, obj.GetLength(0))], transform.position, Quaternion.identity);
        }
        
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));      //invoke spawn at random time interval between min and max
    }

}