using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    public GameObject bulletPrefab;
    public Shooter shooter;
    public Mover mover;
    public Noisemaker noise;
    public float shootForce;
    public float damageDone;
    public Transform shootPoint;
    public float nextShootTime;
    public float timeBetweenShots;

    // Start is called before the first frame update
    public virtual void Start()
    {
        mover = GetComponent<Mover>();
        shooter = GetComponent<Shooter>();
        noise = GetComponent<Noisemaker>();
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    public abstract void MoveForward();

    public abstract void MoveBackward();

    public abstract void RotateClockwise();

    public abstract void RotateCounterClockwise();

    public abstract void Shoot();

    public abstract void TurnTowards(Vector3 targetPosition);

    public abstract void TurnAway(Vector3 targetPosition);
}
