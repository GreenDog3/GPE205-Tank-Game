using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class HealthPowerup : Powerup
{   //how much health we healin
    public float healthToAdd;

    public override void Apply(PowerupManager target)
    {
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.HealDamage(healthToAdd);
        }
    }

    public override void Remove(PowerupManager target)
    {
        //doesn't get removed, it's just one and done
    }
}
