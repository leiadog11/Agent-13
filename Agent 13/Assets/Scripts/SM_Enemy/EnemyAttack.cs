using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyState
{
    public EnemyAttack(EnemyStateController esc) : base(esc) { }

    public override void CheckTransitions()
    {

    }

    public override void Act()
    {
        esc.playerUI.GetComponent<PlayerUI>().lose.SetActive(true);
        esc.playerUI.GetComponent<PlayerUI>().visible.SetActive(false);
        esc.playerUI.GetComponent<PlayerUI>().hidden.SetActive(false);
        esc.playerUI.GetComponent<PlayerUI>().restart.SetActive(true);
        esc.playerUI.GetComponent<PlayerUI>().gameOver = true;
    }
}
