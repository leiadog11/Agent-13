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
       
    }

    public override void CheckTransitions()
    {
        esc.StartCoroutine(changeTime());
        if (canChange)
        {
            esc.SetState(new EnemyNavigation(esc));
            canChange = false;
        }
    }

    public override void Act()
    {

    }

    public override void OnStateExit()
    {

    }

    private IEnumerator changeTime()
    {
        yield return new WaitForSeconds(3);
        canChange = true;
    }
}
