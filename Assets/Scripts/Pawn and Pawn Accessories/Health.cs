using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public Pawn myPawn;
    public Controller myController;
    public int pointsToAdd;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        myPawn = GetComponent<Pawn>();
        myController = myPawn.controller;
        currentHealth = maxHealth;

    }

    void Update()
    {
        image.fillAmount = currentHealth / maxHealth;
        if (IsBoundaryBreaking() == true)
        {
            Die(myPawn);
            GameManager.instance.TryGameOver();
        }
        GameManager.instance.TryGameOver();
    }

    public void TakeDamage(float amount, Pawn owner)
    {
        currentHealth = currentHealth - amount; //damages tank

        if (currentHealth <= 0) 
        { //When your HP reaches 0, you lose!
            Die(owner);
        }
    }

    public void HealDamage(float amount)
    {
        currentHealth = currentHealth + amount;
        if (currentHealth > maxHealth)
        { //clamps health variable
            currentHealth = maxHealth;
        }
    }

    public void Die(Pawn killer) 
    {
        Debug.Log(killer.name + " DESTROYED " + gameObject.name + " with FACTS and LOGIC");
        if (killer.controller != null)
        {
            killer.controller.AddToScore(pointsToAdd);
        }
        myController.lives--;
        if (myController.lives > 0)
        {   //If we have lives left
            GameManager.instance.RespawnPlayer(myController);
            Destroy(gameObject);
        }
        else
        {
            Destroy(myController);
            Destroy(gameObject);
            GameManager.instance.TryGameOver();
        }

    }

    public bool IsBoundaryBreaking()
    {
        if (myPawn.transform.position.y <= -10)
        {
            return true;
        }
        return false;
    }
}
