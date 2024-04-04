using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyToCamera : EnemyState
{
    public EnemyToCamera(EnemyStateController esc) : base(esc) { }

    public override void OnStateEnter()
    {
        esc.animator.SetInteger("AnimationState", 4);
        esc.m_Agent.speed = 8;
        esc.m_Agent.acceleration = 10;
    }

    public override void Act()
    {
        esc.source.clip = esc.running;
        esc.source.Play();
        esc.m_Agent.destination = esc.cc.GetComponent<CameraController>().cameraPos.position;
    }

    public override void CheckTransitions()
    {
        float dist = Vector3.Distance(esc.transform.position, esc.cc.GetComponent<CameraController>().cameraPos.position);
        if (dist < 8f)
        {
            esc.m_Agent.speed = 5;
            esc.m_Agent.acceleration = 8;
            esc.SetState(new EnemyIdle(esc));
            esc.cc.GetComponent<CameraController>().alert = false;
        }

        if (esc.found && esc.player.GetComponent<Invisible>().invisible == false)
        {
            esc.SetState(new EnemyFound(esc));
        }

        float dist2 = Vector3.Distance(esc.transform.position, esc.player.transform.position);
        if (dist2 < 5f && esc.player.GetComponent<Invisible>().invisible == false)
        {
            esc.SetState(new EnemyFound(esc));
        }
    }
}
