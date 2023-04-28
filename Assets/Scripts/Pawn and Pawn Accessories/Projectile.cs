using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float damageDone;
    public Pawn owner;

    public void OnCollisionEnter(Collision other)
    {
        Health otherHealth = other.gameObject.GetComponent<Health>();

        if (otherHealth!= null )
        {
            otherHealth.TakeDamage(damageDone, owner);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
