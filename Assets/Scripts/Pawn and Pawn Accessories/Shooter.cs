using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float projectileDespawnTime;

    public void Shoot(GameObject bulletPrefab, float shootForce, float damageDone, Transform offset, Pawn shooter)
    {
        //instantiate a bullet to shoot
        GameObject theBullet = Instantiate(bulletPrefab, offset.position, transform.rotation);
        //get projectile data
        Projectile projectile = theBullet.GetComponent<Projectile>();

        if (projectile != null ) 
        {
            projectile.damageDone = damageDone;
            projectile.owner = shooter;
        }

        Rigidbody bulletRb = theBullet.GetComponent<Rigidbody>();
        if (bulletRb != null ) 
        {// propel bullet at high speeds
            bulletRb.AddForce(transform.forward * shootForce);
        }
        //Destroy the bullet after some time
        Destroy(theBullet, projectileDespawnTime);
    }
}
