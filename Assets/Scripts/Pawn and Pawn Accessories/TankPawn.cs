using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        nextShootTime= Time.time + timeBetweenShots;
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    public override void MoveForward()
    {
        mover.Move(transform.forward, moveSpeed);
        if (noise != null)
        {
            noise.MakeNoise(10);
        }
    }

    public override void MoveBackward()
    {
        mover.Move(transform.forward, -moveSpeed);
        if (noise != null)
        {
            noise.MakeNoise(10);
        }
    }

    public override void RotateClockwise()
    {
        mover.Rotate(turnSpeed);
        if (noise != null)
        {
            noise.MakeNoise(5);
        }
    }

    public override void RotateCounterClockwise()
    {
        mover.Rotate(-turnSpeed);
        if (noise != null)
        {
            noise.MakeNoise(5);
        }
    }

    public override void Shoot()
    {
        if (Time.time >= nextShootTime)
        { // if we can shoot, shoot
            shooter.Shoot(bulletPrefab, shootForce, damageDone, shootPoint, this);
            if (noise != null)
            {
                noise.MakeNoise(20);
            }
            
            //set the next time we can shot orb
            nextShootTime = Time.time + timeBetweenShots; //sets the next time we can shoot again
        }

    }

    public override void TurnTowards(Vector3 targetPosition)
    {
        //Find the vector from here to there
        Vector3 vectorToTargetPosition = targetPosition - transform.position;
        //Find the quaternion that lets us look at the vector from here to there
        Quaternion look = Quaternion.LookRotation(vectorToTargetPosition, transform.up);
        //rotate to slightly down the quaternion that lets us look at the vector from here to there
        transform.rotation = Quaternion.RotateTowards(transform.rotation, look, turnSpeed * Time.deltaTime);
    }

    public override void TurnAway(Vector3 targetPosition)
    {
        //Find the vector from here to there
        Vector3 vectorToTargetPosition = targetPosition - transform.position;
        //Find the quaternion that lets us look away from the vector from here to there
        Quaternion look = Quaternion.LookRotation(-vectorToTargetPosition, transform.up);
        //rotate to slightly down the quaternion that lets us look away from the vector from here to there
        transform.rotation = Quaternion.RotateTowards(transform.rotation, look, turnSpeed * Time.deltaTime);
    }
}
