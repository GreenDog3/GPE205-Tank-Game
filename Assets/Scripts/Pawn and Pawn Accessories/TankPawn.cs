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
    }

    public override void MoveBackward()
    {
        mover.Move(transform.forward, -moveSpeed);
    }

    public override void RotateClockwise()
    {
        mover.Rotate(turnSpeed);
    }

    public override void RotateCounterClockwise()
    {
        mover.Rotate(-turnSpeed);
    }

    public override void Shoot()
    {
        if (Time.time >= nextShootTime)
        { // if we can shoot, shoot
            shooter.Shoot(bulletPrefab, shootForce, damageDone, shootPoint, this);

            nextShootTime = Time.time + timeBetweenShots; //sets the next time we can shoot again
        }

    }
}
