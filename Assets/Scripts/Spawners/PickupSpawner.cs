using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject pickupPrefab;
    public float spawnDelay;
    private float nextSpawnTime;
    private GameObject spawnedPickup;
    // Start is called before the first frame update
    void Start()
    {
        //sets the inital spawn time
        nextSpawnTime= Time.time + spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        //Make sure there isn't already a pickup
        if (spawnedPickup == null)
        {
            if (Time.time > nextSpawnTime)
            {
                //It's PickupSpawnin' time!
                //PickupSpawns all over those guys
                spawnedPickup = Instantiate(pickupPrefab, transform.position, Quaternion.identity) as GameObject;
                nextSpawnTime = Time.time + spawnDelay;
            }
        }
        else
        {
            //It's not PickupSpawnin' time!
            //doesn't PickupSpawn all over those guys
            nextSpawnTime= Time.time + spawnDelay;
        }
    }
}
