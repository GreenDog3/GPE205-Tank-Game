using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public HealthPowerup powerup;
    public void OnTriggerEnter(Collider other)
    {
        //gets the powerup manager of whatever passed through
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();

        if (powerupManager != null)
        {
            // Add the powerup to the cooler i mean manager
            // I think the health pickup would be diet coke
            powerupManager.Add(powerup);

            // Destroy the physical manifestation of health 
            Destroy(gameObject);
        }

    }
}
