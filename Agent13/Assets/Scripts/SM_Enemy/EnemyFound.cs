using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFound : EnemyState
{
    public EnemyFound(EnemyStateController esc) : base(esc) { }

    [SerializeField] private Transform PlatformDestination;
    [SerializeField] private GameObject Enemy;

    public override void OnStateEnter()
    {
        //esc.m_Agent.speed += 5;
        //esc.m_Agent.acceleration += 2;
    }

    public override void CheckTransitions()
    {
        float dist = Vector3.Distance(esc.transform.position, esc.player.transform.position);

        if(dist < 4.0)
        {
            esc.SetState(new EnemyAttack(esc));
        }

        else if(esc.combat == true)
        {
            esc.SetState(new EnemyIdle(esc));
        }
    }

    public override void Act()
    {
        esc.source.clip = esc.running;
        esc.source.Play();
        esc.m_Agent.destination = esc.player.transform.position;
    }

    public override void OnStateExit()
    {
        esc.m_Agent.destination = esc.transform.position;
    }
}
