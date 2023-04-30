using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SpeedPowerup : Powerup
{   //how fast we zoomin
    public float speedToAdd;

    public override void Apply(PowerupManager target)
    {
        Pawn targetPawn = target.GetComponent<Pawn>();
        if (targetPawn != null )
        {
            targetPawn.moveSpeed = targetPawn.moveSpeed + speedToAdd;
        }
    }

    public override void Remove(PowerupManager target)
    {
        Pawn targetPawn = target.GetComponent<Pawn>();
        if (targetPawn != null)
        {
            targetPawn.moveSpeed = targetPawn.moveSpeed - speedToAdd;
        }
    }
}
