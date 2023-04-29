using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public abstract class AIController : Controller
{
    public enum AIStates {Idle, Chase, Attack, Flee, ChooseTarget, Patrol, Turn};
    public AIStates currentState;
    public float timeEnteredCurrentState;
    public GameObject AITarget;
    public float hearingDistance;
    public List<Transform> waypoints;
    public int currentWaypoint;





    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    public virtual void ChangeState(AIStates newState)
    {
        //Tells the AI that we changed states
        timeEnteredCurrentState = Time.time;
        currentState = newState;
    }

    public virtual void DoIdleState()
    {
        //The crew in the tank is probably playing Fluxx during this state.
    }

    public virtual void DoTargetPlayer1State() 
    { //If the Game Manager exists
        if (GameManager.instance != null)
        {//And it has a list of players
            if (GameManager.instance.players != null)
            {// And it has players to list
                if (GameManager.instance.players.Count > 0)
                {//Target the first player in the list
                    AITarget = GameManager.instance.players[0].pawn.gameObject;
                }
            }
        }
    }

    public virtual GameObject GetNearestPlayer()
    {//Assume that player 1 is closest as a starting point
        GameObject nearestPlayer = GameManager.instance.players[0].pawn.gameObject;
        float nearestPlayerDistance = Vector3.Distance(pawn.transform.position, nearestPlayer.transform.position);
        //check to see if other players are closer
        for (int index = 1; index <GameManager.instance.players.Count; index++)
        {   
            float tempDistance = Vector3.Distance(pawn.transform.position, GameManager.instance.players[index].transform.position);
            if (tempDistance < nearestPlayerDistance)
            {   //If the next player in the list is closer, set them to the new closest
                nearestPlayer = GameManager.instance.players[index].pawn.gameObject;
                nearestPlayerDistance = tempDistance;
            }
        }
        //a carrier pidgeon dives into the tank with a piece of paper in its mouth, containing the nearest player
        return nearestPlayer;
    }

    public virtual void DoPatrolState()
    {
        Vector3 tempTargetLocation = waypoints[currentWaypoint].position;
        //move to the waypoint
        tempTargetLocation = new Vector3(tempTargetLocation.x, pawn.transform.position.y, tempTargetLocation.z);
        Chase(tempTargetLocation);
        //once we reach it, move to the next
        if (Vector3.Distance(pawn.transform.position, tempTargetLocation) <= 1)
        {
            currentWaypoint++;
        }
        //once we reach the last one, loop to the first
        if(currentWaypoint >= waypoints.Count)
        {
            currentWaypoint = 0;
        }

    }    

    public virtual void DoChangeTargetState()
    {   //if the gamemanager is real
        if (GameManager.instance != null)
        {   //if the list of players is real
            if (GameManager.instance.players != null)
            {   //if the players in it are real
                if (GameManager.instance.players.Count > 0)
                {   //set IsLivingInSimulation to false and target the pawn of the player closest to us
                    AITarget = GetNearestPlayer();
                }
            }
        }
    }

    public virtual void DoChaseState()
    {
        if (AITarget != null)
        {
            Chase(AITarget);
        }
        else
        {
            Debug.Log("god has cursed me for my hubris and my work is never finished");
        }
    }

    public virtual void DoFleeState()
    {
        if (AITarget != null)
        {
            Flee(AITarget);
        }
        else
        {
            Debug.Log("what god did i annoy");
        }
    }

    public virtual void Flee(GameObject fleeTarget)
    {
        if (fleeTarget != null)
        {
            Flee(fleeTarget.transform.position);
        }
    }

    public virtual void Flee(Transform fleeTarget)
    {
        Flee(fleeTarget.gameObject);
    }

    public virtual void Flee(Controller fleeTarget)
    {
        Flee(fleeTarget.pawn.gameObject);
    }

    public virtual void Flee(Vector3 fleeTarget)
    {
        if (fleeTarget != null)
        {
            //turn away
            pawn.TurnAway(fleeTarget);
            //BURN RUBBER
            pawn.MoveForward();
        }
    }

    public virtual void Chase(GameObject chaseTarget)
    {
        if (chaseTarget != null)
        {
            Chase(chaseTarget.transform.position);
        }
        else
        {
            Debug.Log("Null Target");
        }
    }

    public virtual void Chase(Controller chaseTarget)
    {
        Chase(chaseTarget.pawn.gameObject);
    }

    public virtual void Chase(Vector3 chaseTarget)
    {
        if (chaseTarget != null)
        {
            //Turn toward target
            pawn.TurnTowards(chaseTarget);
            //the target is a laser pointer and you are a cat
            pawn.MoveForward();
        }
        else
        {
            Debug.Log("Null Target! :(");
        }
    }

    public virtual void DoTurnState()
    {
        TurnTowards(AITarget);
    }

    public virtual void DoTurnAwayState()
    {
        TurnAway(AITarget);
    }

    public virtual void TurnTowards(Controller target)
    {
        TurnTowards(target.pawn.gameObject);
    }

    public virtual void TurnTowards(GameObject target)
    {
        if (target != null)
        {
            TurnTowards(target.transform.position);
        }
    }

    public virtual void TurnTowards(Vector3 target)
    {
        pawn.TurnTowards(target);
    }

    public virtual void TurnAway(GameObject target)
    {
        if (target != null)
        {
            TurnAway(target.transform.position);
        }
    }

    public virtual void TurnAway(Controller target)
    {
        TurnAway(target.pawn.gameObject);
    }

    public virtual void TurnAway(Vector3 target)
    {
        pawn.TurnAway(target);
    }

    public virtual void DoAttackState()
    {
        pawn.Shoot();
    }

    public virtual bool IsTimePassed(float amountOfTime)
    {
        if (Time.time - timeEnteredCurrentState >= amountOfTime)
        {
            return true;
        }
        return false;
    }

    public bool IsCanHear(GameObject target)
    {
        if (target != null)
        {   //get the noisemaker of the target
            Noisemaker noiseMaker = target.GetComponent<Noisemaker>();
            if (noiseMaker == null)
            {   //if there's no noise maker then we can't hear the noise
                return false;
            }
            
            if (noiseMaker.noiseDistance <=0)
            {   //if they aren't making noise, we can't hear it
                return false;
            }
            //If they are making noise, add the noise to the hearing distance
            float totalDistance = noiseMaker.noiseDistance + hearingDistance;

            //If the distance between the pawn and target is less than this, we can hear them
            if (Vector3.Distance(pawn.transform.position, target.transform.position) <=totalDistance)
            {
                return true;
            }
            else
            {   // if not, we can't hear them
                return false;
            }
        }
        return false;
    }

}
