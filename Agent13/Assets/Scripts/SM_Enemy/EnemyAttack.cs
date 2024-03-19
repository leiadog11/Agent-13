using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class EnemyAttack : EnemyState
{
    public EnemyAttack(EnemyStateController esc) : base(esc) { }

    private int health = 20;
    private int counter = 0;
    int randomAttack = Random.Range(1, 6);
    private bool canAttack;

    public override void OnStateEnter()
    {
        canAttack = true;

        //bring combat grid in
        esc.combatGrid.GetComponent<Animator>().SetBool("found", true);
        esc.animator.SetInteger("AnimationState", 3);

        //set player move speed and turn speed to 0
        esc.playerMove.GetComponent<DynamicMoveProvider>().moveSpeed = 0;
        esc.playerTurn.GetComponent<ContinuousTurnProviderBase>().turnSpeed = 0;

        //put enemy in front of player
        esc.gameObject.transform.position = esc.player.transform.position + esc.player.transform.forward * 5f;
        esc.gameObject.transform.LookAt(esc.player.transform);

        //increase found counter - play Jack voice lines - start combat tutorial with Comba-chan
    }

    public override void CheckTransitions()
    {
        if(health <= 0)
        {
            //die
            //restore player move and turn speed
            //remove combat grid
        }
    }

    public override void Act()
    {
        if(canAttack)
        {
            Attack(3, 2);
        }
        
        //begin doing random attacks
        //keep enemy health in track
    }

    public void Attack(int amount, float timeInBetween)
    {
        if(counter == amount)
        {
            counter = 0;
            canAttack = false;
            esc.animator.SetInteger("CombatState", 0);
            GetHitByPlayer();
        }
        else
        {
            randomAttack = Random.Range(1, 6);
            switch (randomAttack)
            {
                case 1:
                    esc.leftSpawn.GetComponent<CombatAttacks>().Spawn();
                    esc.animator.SetInteger("CombatState", 1);
                    break;
                case 2:
                    esc.topSpawn.GetComponent<CombatAttacks>().Spawn();
                    esc.animator.SetInteger("CombatState", 2);
                    break;
                case 3:
                    esc.rightSpawn.GetComponent<CombatAttacks>().Spawn();
                    esc.animator.SetInteger("CombatState", 3);
                    break;
                case 4:
                    esc.bottomSpawn.GetComponent<CombatAttacks>().Spawn();
                    esc.animator.SetInteger("CombatState", 4);
                    break;
                case 5:
                    //middle attack
                    esc.animator.SetInteger("CombatState", 5);
                    break;
            }
            esc.StartCoroutine(WaitForAttack(amount, timeInBetween));
            counter++;
        }

    }

    public void GetHitByPlayer()
    {

    }

    private IEnumerator WaitForAttack(int amount, float time)
    {
        yield return new WaitForSeconds(time);
        Attack(amount, time);
    }


}
