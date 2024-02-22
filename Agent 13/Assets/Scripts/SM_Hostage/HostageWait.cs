using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostageWait : HostageState
{
    public HostageWait(HostageStateController hsc) : base(hsc) { }

    public override void OnStateEnter()
    {

    }

    public override void CheckTransitions()
    {
        float dist = Vector3.Distance(hsc.transform.position, hsc.player.transform.position);
        if (dist < 6.0)
        {
            hsc.SetState(new HostageFollow(hsc));
        }
    }

    public override void Act()
    {

    }

    public override void OnStateExit()
    {

    }
}
