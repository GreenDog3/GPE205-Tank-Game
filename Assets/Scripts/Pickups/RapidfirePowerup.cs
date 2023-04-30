using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class RapidfirePowerup : Powerup
{   //how fast we shootin
    public float timeToSubtract;
    public float timeToReturnTo;

    public override void Apply(PowerupManager target)
    {
        Pawn targetPawn = target.GetComponent<Pawn>();
        if (targetPawn != null)
        {
            targetPawn.timeBetweenShots = targetPawn.timeBetweenShots - timeToSubtract;
            if (targetPawn.timeBetweenShots <= 0 )
            {
                targetPawn.timeBetweenShots = 0.1f;
            }
        }
    }

    public override void Remove(PowerupManager target)
    {
        Pawn targetPawn = target.GetComponent<Pawn>();
        if (targetPawn != null)
        {
            targetPawn.timeBetweenShots = timeToReturnTo;
        }
    }
}
