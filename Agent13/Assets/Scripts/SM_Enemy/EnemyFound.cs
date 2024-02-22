using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFound : EnemyState
{
    public EnemyFound(EnemyStateController esc) : base(esc) { }

    [SerializeField] private Transform PlatformDestination;
    [SerializeField] private GameObject Enemy;

    public override void CheckTransitions()
    {
        float dist = Vector3.Distance(esc.transform.position, esc.player.transform.position);

        if(dist < 4.0)
        {
            esc.ChangeMaterial();
            esc.SetState(new EnemyAttack(esc));
        }
    }

    public override void Act()
    {
        esc.m_Agent.destination = esc.player.transform.position;
    }
}
