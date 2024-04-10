using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyIdle : EnemyState
{
    public EnemyIdle(EnemyStateController esc) : base(esc) { }
    private bool canChange = false;

    public override void OnStateEnter()
    {
        esc.animator.SetInteger("AnimationState", 0);
    }

    public override void CheckTransitions()
    {
        esc.StartCoroutine(changeTime());
        if (canChange)
        {
            esc.SetState(new EnemyNavigation(esc));
            canChange = false;
        }

        if (esc.found && esc.player.GetComponent<Invisible>().invisible == false)
        {
            esc.source.Stop();
            esc.source.clip = esc.hey;
            esc.source.Play();
            esc.animator.SetInteger("AnimationState", 2);
            esc.StartCoroutine(WaitForPoint());
            esc.SetState(new EnemyFound(esc));
        }

        float dist2 = Vector3.Distance(esc.transform.position, esc.player.transform.position);
        if (dist2 < 10f && esc.player.GetComponent<Invisible>().invisible == false)
        {
            esc.source.Stop();
            esc.source.clip = esc.hey;
            esc.source.Play();
            esc.animator.SetInteger("AnimationState", 2);
            esc.StartCoroutine(WaitForPoint());
            esc.SetState(new EnemyFound(esc));
        }
    }

    public override void Act()
    {
        esc.CastRay(esc.transform.forward); //Forward
        esc.CastRay(Quaternion.AngleAxis(-30, esc.transform.up) * esc.transform.forward); // Slightly left
        esc.CastRay(Quaternion.AngleAxis(30, esc.transform.up) * esc.transform.forward); // Slightly right
        esc.CastRay(Quaternion.AngleAxis(-15, esc.transform.up) * esc.transform.forward); // Very Slightly left
        esc.CastRay(Quaternion.AngleAxis(15, esc.transform.up) * esc.transform.forward); // Very Slightly right
    }

    public override void OnStateExit()
    {

    }

    private IEnumerator changeTime()
    {
        yield return new WaitForSeconds(3);
        canChange = true;
    }

    private IEnumerator WaitForPoint()
    {
        yield return new WaitForSeconds(1);
        esc.SetState(new EnemyFound(esc));
    }
}
