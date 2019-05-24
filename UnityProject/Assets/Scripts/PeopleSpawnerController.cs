using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawnerController : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] customers;
    int randomSpawnPoint, randomCustomer;
    public bool spawnAllowed;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCustomer", 0f, 1f);
    }

    void SpawnCustomer()
    {
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomCustomer = Random.Range(0, customers.Length);
            Instantiate(customers[randomCustomer], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
    }
}
