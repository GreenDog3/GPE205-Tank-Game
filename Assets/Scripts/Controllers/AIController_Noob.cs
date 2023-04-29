using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController_Noob : AIController
{
    // Start is called before the first frame update
    public override void Start()
    {   //starts idle and adds itself to the enemy list
        ChangeState(AIStates.Idle);
        GameManager.instance.enemies.Add(this);
    }

    // Update is called once per frame
    public override void Update()
    {
        if (pawn != null)
        {
            MakeDecisions();
        }
        else
        {
            Destroy(this);
        }
    }

    public override void MakeDecisions()
    {
        //Honestly "Noob" ended up being kind of a misnomer, but I'm in too deep now.
        //If it hears the player, it will chase for one second, shoot, and then wait.

        switch (currentState)
        {
            case AIStates.Idle:
                DoIdleState();
                if (IsTimePassed(1))
                {
                    ChangeState(AIStates.ChooseTarget);
                }
                break;
            case AIStates.Attack:
                DoAttackState();
                 if (AITarget != null)
                    {
                        ChangeState(AIStates.Chase);
                    }
                break;
            case AIStates.ChooseTarget:
                DoChangeTargetState();
                if (IsCanHear(AITarget))
                {
                    if (AITarget != null)
                    {
                        ChangeState(AIStates.Attack);
                    }
                }
                break;
            case AIStates.Chase:
                DoChaseState();
                if (IsTimePassed(1))
                {
                    ChangeState(AIStates.Idle);
                }
                break;
            

        }
    }

    public void OnDestroy()
    {
        GameManager.instance.enemies.Remove(this);
    }
}
