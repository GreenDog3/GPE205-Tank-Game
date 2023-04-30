using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickup : MonoBehaviour
{
    public SpeedPowerup powerup;

    public void OnTriggerEnter(Collider other)
    {
        //gets the powerup manager of whatever passed through
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();

        if (powerupManager != null)
        {
            // Add the powerup to the cooler i mean manager
            // I think the speed pickup would be red bull
            powerupManager.Add(powerup);

            // Destroy the physical manifestation of speed
            Destroy(gameObject);
        }

    }
}
