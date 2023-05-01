using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float damageDone;
    public Pawn owner;
    public AudioClip impact;
    public AudioSource source;

    void Start()
    {
        source = GameManager.instance.source;
    }
    public void OnCollisionEnter(Collision other)
    {
        Health otherHealth = other.gameObject.GetComponent<Health>();

        if (otherHealth!= null )
        {
            otherHealth.TakeDamage(damageDone, owner);
            Destroy(gameObject);
            source.PlayOneShot(impact, 0.7f);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
