using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController_Sniper : AIController
{
    // Start is called before the first frame update
    public override void Start()
    {
        //Start by idling
        GameManager.instance.enemies.Add(this);
        ChangeState(AIStates.Idle);
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
        //The Sniper will wait until it can hear an enemy, run away from it, and then turn around and shoot at it.

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
                if (IsTimePassed(1))
                {
                    if (IsCanHear(AITarget))
                    {
                        if (AITarget != null)
                        {
                            ChangeState(AIStates.Flee);
                        }
                    }
                    else
                    {
                        ChangeState(AIStates.Idle);
                    }

                }
                break;

            case AIStates.Flee:
                DoFleeState();
                if (IsTimePassed(2))
                {
                    ChangeState(AIStates.Turn);
                }
                break;
            case AIStates.Attack:
                DoAttackState();
                ChangeState(AIStates.ChooseTarget);
                break;

            case AIStates.Turn:
                DoTurnState();
                if (IsTimePassed(2))
                {
                    ChangeState(AIStates.Attack);
                }
                break;

        }
    }

    public void OnDestroy()
    {
        GameManager.instance.enemies.Remove(this);
    }
}
