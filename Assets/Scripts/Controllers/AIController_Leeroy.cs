using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController_Leeroy : AIController
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
        //https://youtu.be/mLyOj_QD4a4?t=82
        //should give you the idea

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
                ChangeState(AIStates.ChooseTarget);
                break;
            case AIStates.ChooseTarget:
                DoChangeTargetState();
                if (IsCanHear(AITarget))
                {
                    if (AITarget != null)
                    {
                        ChangeState(AIStates.Chase);
                    }
                }
                else
                {
                    ChangeState(AIStates.Attack);
                }
                break;
            case AIStates.Chase:
                DoChaseState();
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
