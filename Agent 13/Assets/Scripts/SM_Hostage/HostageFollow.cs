using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostageFollow : HostageState
{
   public HostageFollow(HostageStateController hsc) : base(hsc) { }

    public override void OnStateEnter()
    {

    }

    public override void CheckTransitions()
    {
        float dist = Vector3.Distance(hsc.transform.position, hsc.player.transform.position);
        if (dist < 3.0)
        {
            hsc.SetState(new HostageStop(hsc));
        }

        float dist2 = Vector3.Distance(hsc.transform.position, hsc.goal.transform.position);
        if (dist2 < 6.0)
        {
            hsc.playerUI.GetComponent<PlayerUI>().win.SetActive(true);
            hsc.playerUI.GetComponent<PlayerUI>().hidden.SetActive(false);
            hsc.playerUI.GetComponent<PlayerUI>().visible.SetActive(false);
            hsc.playerUI.GetComponent<PlayerUI>().restart.SetActive(true);
            hsc.playerUI.GetComponent<PlayerUI>().gameOver = true;
            hsc.SetState(new HostageStop(hsc));
        }
    }

    public override void Act()
    {
        hsc.m_Agent.destination = hsc.player.transform.position;
    }

    public override void OnStateExit()
    {

    }
}
