using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyToCamera : EnemyState
{
    public EnemyToCamera(EnemyStateController esc) : base(esc) { }

    public override void OnStateEnter()
    {
        esc.animator.SetInteger("AnimationState", 4);
        esc.speed += 15;
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
        if (dist < 5f)
        {
            esc.speed -= 15;
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
