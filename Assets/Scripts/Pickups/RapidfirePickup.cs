using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidfirePickup : MonoBehaviour
{
    public RapidfirePowerup powerup;

    public void OnTriggerEnter(Collider other)
    {
        //gets the powerup manager of whatever passed through
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();

        if (powerupManager != null)
        {
            // Add the powerup to the cooler i mean manager
            // I think the rapidfire pickup would be la croix
            // I know that one sounds out there but hear me out
            // when youtube scientists destroy soda cans it's always la croix
            // the link is there
            powerupManager.Add(powerup);

            // Destroy the physical manifestation of shoot
            Destroy(gameObject);
        }

    }
}
