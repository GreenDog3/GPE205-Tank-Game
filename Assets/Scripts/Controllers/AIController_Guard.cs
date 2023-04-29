using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController_Guard : AIController
{
    // Start is called before the first frame update
    public override void Start()
    {
        //Starts by idling
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
        //The Guard will patrol the waypoints and turn and shoot at the player if they are in range

        switch (currentState)
        {
            case AIStates.Idle:
                DoIdleState();
                if (IsTimePassed(1))
                {
                    ChangeState(AIStates.ChooseTarget);
                }
                break;
            case AIStates.ChooseTarget:
                DoChangeTargetState();
                if (IsCanHear(AITarget))
                {
                    if (AITarget != null)
                    {
                        ChangeState(AIStates.Turn);
                    }
                }
                else
                {
                    ChangeState(AIStates.Patrol);
                }
                break;
            case AIStates.Patrol:
                DoPatrolState();
                if (IsTimePassed(1))
                {
                    ChangeState(AIStates.ChooseTarget);
                }
                break;

            case AIStates.Turn:
                DoTurnState();
                if (IsTimePassed(1))
                {

                    ChangeState(AIStates.Attack);
                }
                break;
            case AIStates.Attack:
                DoAttackState();
                ChangeState(AIStates.Patrol);
                break;

        }
    }
    public void OnDestroy()
    {
        GameManager.instance.enemies.Remove(this);
    }
}
