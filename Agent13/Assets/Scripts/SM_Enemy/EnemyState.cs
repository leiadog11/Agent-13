using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public abstract class EnemyState 
{
    protected EnemyStateController esc;
    public abstract void CheckTransitions();
    public abstract void Act();
    public virtual void OnStateEnter()
    {

    }

    public virtual void OnStateExit()
    {

    }

    public EnemyState(EnemyStateController esc)
    {
        this.esc = esc;
    }
}
