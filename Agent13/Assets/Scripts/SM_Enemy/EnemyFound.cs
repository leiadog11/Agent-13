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
        esc.m_Agent.speed = 8;
        esc.m_Agent.acceleration = 10;
    }

    public override void CheckTransitions()
    {
        float dist = Vector3.Distance(esc.transform.position, esc.player.transform.position);

        if(dist < 4.0)
        {
            esc.SetState(new EnemyAttack(esc));
        }

        if(esc.combat == true)
        {
            esc.SetState(new EnemyIdle(esc));
        }
    }

    public override void Act()
    {
        // If the character has moved and the audio is not currently playing
        if (esc.transform.position != esc.lastPosition && !esc.source.isPlaying)
        {
            esc.source.pitch = Random.Range(0.9f, 1.2f);
            esc.source.volume = Random.Range(0.4f, 1f);
            esc.source.clip = esc.running;
            esc.source.Play();
        }
        // Update lastPosition for the next frame
        esc.lastPosition = esc.transform.position;
        esc.m_Agent.destination = esc.player.transform.position;
    }

    public override void OnStateExit()
    {
        esc.m_Agent.speed = 5;
        esc.m_Agent.acceleration = 8;
        esc.m_Agent.destination = esc.transform.position;
    }
}
