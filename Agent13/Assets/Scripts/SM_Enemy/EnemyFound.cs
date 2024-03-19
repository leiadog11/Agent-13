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
        esc.speed += 15;
    }

    public override void CheckTransitions()
    {
        float dist = Vector3.Distance(esc.transform.position, esc.player.transform.position);

        if(dist < 4.0)
        {
            esc.SetState(new EnemyAttack(esc));
        }
    }

    public override void Act()
    {
        esc.source.clip = esc.running;
        esc.source.Play();
        esc.m_Agent.destination = esc.player.transform.position;
    }
}
