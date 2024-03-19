using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : EnemyState
{
    private Transform CurrentDestination;

    public EnemyNavigation(EnemyStateController esc) : base(esc) { }

    public override void OnStateEnter()
    {
        esc.animator.SetInteger("AnimationState", 1);
        CurrentDestination = esc.RandomDestination();
        esc.found = false;
    }

    public override void CheckTransitions()
    {
        float dist = Vector3.Distance(esc.transform.position, CurrentDestination.position);
        if (dist < 2.1f)
        {
            esc.SetState(new EnemyIdle(esc));
        }

        if (esc.found && esc.player.GetComponent<Invisible>().invisible == false)
        {
            esc.source.clip = esc.hey;
            esc.source.Play();
            esc.animator.SetInteger("AnimationState", 2);
            esc.StartCoroutine(WaitForPoint());

        }

        float dist2 = Vector3.Distance(esc.transform.position, esc.player.transform.position);
        if (dist2 < 5f && esc.player.GetComponent<Invisible>().invisible == false)
        {
            esc.source.clip = esc.hey;
            esc.source.Play();
            esc.animator.SetInteger("AnimationState", 2);
            esc.StartCoroutine(WaitForPoint());
        }

        if (esc.cc.GetComponent<CameraController>().alert == true)
        {
            esc.SetState(new EnemyToCamera(esc));
        }

    }

    public override void Act()
    {
        esc.source.clip = esc.footsteps;
        esc.source.Play();
        esc.m_Agent.destination = CurrentDestination.position;

        esc.CastRay(esc.transform.forward); //Forward
        esc.CastRay(Quaternion.AngleAxis(-30, esc.transform.up) * esc.transform.forward); // Slightly left
        esc.CastRay(Quaternion.AngleAxis(30, esc.transform.up) * esc.transform.forward); // Slightly right
        esc.CastRay(Quaternion.AngleAxis(-15, esc.transform.up) * esc.transform.forward); // Very Slightly left
        esc.CastRay(Quaternion.AngleAxis(15, esc.transform.up) * esc.transform.forward); // Very Slightly right
    }

    public override void OnStateExit()
    {
        CurrentDestination = esc.RandomDestination();
        esc.found = false;
    }

    private IEnumerator WaitForPoint()
    {
        yield return new WaitForSeconds(1);
        esc.SetState(new EnemyFound(esc));
    }

}
