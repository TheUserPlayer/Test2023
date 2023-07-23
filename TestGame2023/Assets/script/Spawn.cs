using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[]  Apple;
    public GameObject SpawnPoint;
    public float Spawn1;
     float TimeS = 0.0f;
    void Update()
    {
        if( Time.time > TimeS)
        {
            TimeS = Time.time + Spawn1;
            int randEnemy = UnityEngine.Random.Range(0, Apple.Length);
            Instantiate(Apple[randEnemy],SpawnPoint.transform.position,Quaternion.identity);
        }
        
    }
}
