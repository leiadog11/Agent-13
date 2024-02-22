using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HostageState
{
    protected HostageStateController hsc;
    public abstract void CheckTransitions();
    public abstract void Act();
    public virtual void OnStateEnter()
    {

    }

    public virtual void OnStateExit()
    {

    }

    public HostageState(HostageStateController hsc)
    {
        this.hsc = hsc;
    }
}
