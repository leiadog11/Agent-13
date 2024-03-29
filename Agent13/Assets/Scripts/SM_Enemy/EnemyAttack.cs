using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class EnemyAttack : EnemyState
{
    public EnemyAttack(EnemyStateController esc) : base(esc) { }

    private int health = 20;
    private int counter = 0;
    int randomAttack = Random.Range(1, 6);
    private bool canAttack;
    private Vector3 lastPos;
    public float xOffset, yOffset, zOffset;

    public override void OnStateEnter()
    {
        //set player move speed and turn speed to 0
        esc.move.SetActive(false);
        esc.turn.SetActive(false);
        esc.invis.SetActive(false);

        //bools
        //if tutorial has been completed:
        esc.StartCoroutine(StartUp());

        //else: tutorial

        esc.combat = true;

        //teleport enemy and player to combat grid
        lastPos = esc.player.transform.position;
        esc.player.transform.position = esc.playerTP.transform.position;

        //bring combat grid in
        esc.combatGrid.GetComponent<Animator>().SetBool("found", true);
        esc.animator.SetInteger("AnimationState", 3);

        //make enemy face player
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
        esc.transform.position = esc.enemyTP.transform.position + new Vector3(xOffset, yOffset, zOffset);

        esc.gameObject.transform.LookAt(esc.player.transform);
        if (canAttack)
        {
            Attack(3, 2);
        }
        
        //begin doing random attacks
        //keep enemy health in track
    }

    public override void OnStateExit()
    {
        esc.move.SetActive(true);
        esc.turn.SetActive(true);
        esc.invis.SetActive(true);
        esc.player.transform.position = lastPos;
    }

    public void Attack(int amount, float timeInBetween)
    {
        canAttack = false;

        if(counter >= amount)
        {
            counter = 0;
            esc.animator.SetInteger("CombatState", 0);
            GetHitByPlayer();
        }
        else
        {
            randomAttack = Random.Range(1, 5);
            switch (randomAttack)
            {
                case 1:
                    esc.StartCoroutine(WaitToSpawn(1));
                    esc.leftWarning.SetActive(true);
                    esc.animator.SetInteger("CombatState", 1);
                    break;
                case 2:
                    esc.StartCoroutine(WaitToSpawn(2));
                    esc.topWarning.SetActive(true);
                    esc.animator.SetInteger("CombatState", 2);
                    break;
                case 3:
                    esc.StartCoroutine(WaitToSpawn(3));
                    esc.rightWarning.SetActive(true);
                    esc.animator.SetInteger("CombatState", 3);
                    break;
                case 4:
                    esc.StartCoroutine(WaitToSpawn(4));
                    esc.bottomWarning.SetActive(true);
                    esc.animator.SetInteger("CombatState", 4);
                    break;
                //case 5:
                    //middle attack
                    //esc.animator.SetInteger("CombatState", 5);
                    //break;
            }
            esc.StartCoroutine(WaitForNextAttack(amount, timeInBetween));
            counter++;
        }

    }

    public void GetHitByPlayer()
    {

    }

    private IEnumerator WaitForNextAttack(int amount, float time)
    {
        yield return new WaitForSeconds(time);
        Attack(amount, time);
    }

    private IEnumerator WaitToSpawn(int spawn)
    {
        yield return new WaitForSeconds(1f);
        switch(spawn)
        {
            case 1:
                esc.leftSpawn.GetComponent<CombatAttacks>().Spawn();
                esc.leftWarning.SetActive(false);
                break;
            case 2:
                esc.topSpawn.GetComponent<CombatAttacks>().Spawn();
                esc.topWarning.SetActive(false);
                break;
            case 3:
                esc.rightSpawn.GetComponent<CombatAttacks>().Spawn();
                esc.rightWarning.SetActive(false);
                break;
            case 4:
                esc.bottomSpawn.GetComponent<CombatAttacks>().Spawn();
                esc.bottomWarning.SetActive(false);
                break;
        }
    }

    private IEnumerator StartUp()
    {
        yield return new WaitForSeconds(4);
        canAttack = true; 
    }


}
