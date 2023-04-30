using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public List<Powerup> powerups;
    // Start is called before the first frame update
    void Start()
    {
        powerups = new List<Powerup>();
    }

    // Update is called once per frame
    void Update()
    {
        DecrementPowerupTimers();
    }

    public void Add(Powerup powerupToAdd)
    {
        //i think powerups are like cans of soda or perhaps juice.
        //here is where we put one in the cooler
        powerupToAdd.Apply(this);
        //and we add it to the list of things in the cooler
        powerups.Add(powerupToAdd);
    }

    public void Remove(Powerup powerupToRemove)
    {
        //this is when the can gets thrown in the garbage
        powerupToRemove.Remove(this);
        powerups.Remove(powerupToRemove);
    }

    public void DecrementPowerupTimers()
    {
        List<Powerup> removedPowerupQueue = new List<Powerup>();
        foreach (Powerup pu in powerups)
        {
            //this is where we drink the soda from the can
            pu.duration -= Time.deltaTime;

            //when your can is empty, you throw it away in a garbage bin
            if (pu.duration <= 0)
            {
                removedPowerupQueue.Add(pu);
            }
        }
        //take the garbage bin to the dumpster. Thankfully we don't have to go down a flight of stairs to do that here.
        //Unrelated rant: The second floor is easily the worst floor of the dorms to live on.
        //Like at least with the third floor, you have easy access to the kitchen, laundry room, and vending machines.
        //On the first floor, you don't have to carry things up stairs, which would've been helpful moving in.
        //On the second floor you both have to carry thins up stairs AND have to go to the third floor to do anything there.
        //Like what do we get? The movie room and game room? I don't use those nearly as often as the kitchen.
        //There's no winning on the second floor.
        //I will die on this hill for as long as I live.
        //like come on at least give us the vending machines
        //anyway yeah. remove the powerups in the removal queue
        foreach (Powerup powerup in removedPowerupQueue)
        {
            Remove(powerup);
        }
    }
}
