using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

public class VoiceLines : MonoBehaviour
{
    public GameObject player;
    public GameObject move;
    public GameObject turn;
    public GameObject cam;
    public GameObject invis;
    public GameObject black;
    public GameObject healthDisplay;
    public GameObject keycardDisplay;
    public GameObject gun;
    public GameObject[] enemies;
    private AudioSource source;
    private int line;

    public AudioClip line1, line2, line3, line4, line5, line6, line7, line8, line9, line10, line11, line12, line13, line14, line15, line16, line17, line18, line19, line20, line21, line22;
    public AudioClip vent, fall;
    public GameObject gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        player = gameManager.GetComponent<GameManager>().player;
        healthDisplay = gameManager.GetComponent<GameManager>().playerHealth;
        keycardDisplay = gameManager.GetComponent<GameManager>().keycardDisplay;
        turn = gameManager.GetComponent<GameManager>().turn;
        move = gameManager.GetComponent<GameManager>().move;
        invis = gameManager.GetComponent<GameManager>().invis;
    }

    // Start is called before the first frame update
    void Start()
    {
        line = 0;
        DontDestroyOnLoad(gameObject);
        source = gameObject.GetComponent<AudioSource>();
        invis.SetActive(false);
        healthDisplay.SetActive(false);
        keycardDisplay.SetActive(false);
        move.SetActive(false);
        turn.SetActive(false);
        StartCoroutine(WaitForLine(2));
    }

    public void Lines()
    {
        switch (line)
        {
            case 0:
                source.clip = line1;
                source.Play();
                line++;
                StartCoroutine(WaitForLine(10.5f));
                break;
            case 1:
                source.clip = line2;
                source.Play();
                line++;
                StartCoroutine(WaitForLine(3.5f));
                break;
            case 2:
                source.clip = vent;
                source.Play();
                line++;
                StartCoroutine(WaitForLine(2f));
                break;
            case 3:
                source.clip = fall;
                source.Play();
                line++;
                StartCoroutine(WaitForLine(2f));
                break;
            case 4:
                black.GetComponent<Animator>().Play("BlackOut");
                gun.GetComponent<Gun>().SpawnGun();
                move.SetActive(true);
                turn.SetActive(true);
                source.clip = line3;
                source.Play();
                line++;
                break;
            case 5:
                source.clip = line4;
                source.Play();
                line++;
                StartCoroutine(WaitForLine(2.2f));
                break;
            case 6:
                source.clip = line5;
                source.Play();
                line++;
                break;
            case 7:
                source.clip = line8;
                source.Play();
                line++;
                break;
            case 8:
                move.SetActive(false);
                turn.SetActive(false);
                source.clip = line9;
                DestroyAreaZero();
                source.Play();
                line++;
                StartCoroutine(WaitForLine(12.2f));
                break;
            case 9:
                source.clip = line10;
                source.Play();
                line++;
                StartCoroutine(WaitForLine(4.1f));
                break;
            case 10:
                move.SetActive(true);
                turn.SetActive(true);
                invis.SetActive(true);
                line++;
                break;
            case 11:
                source.clip = line17;
                source.Play();
                healthDisplay.SetActive(true);
                line++;
                StartCoroutine(Reactivate(5.1f));
                break;

        }
    }

    public IEnumerator WaitForLine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        source.Stop();
        Lines();
    }

    public void PlaySpecificLine(int number)
    {
        switch (number)
        {
            case 6:
                source.clip = line6;
                source.Play();
                break;
            case 7:
                source.clip = line7;
                source.Play();
                break;
            case 11:
                foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<EnemyStateController>().SetState(new EnemyIdle(enemy.GetComponent<EnemyStateController>()));
                    enemy.GetComponent<NavMeshAgent>().speed = 0;
                    enemy.GetComponent<NavMeshAgent>().acceleration = 0;
                }
                move.SetActive(false);
                turn.SetActive(false);
                source.clip = line11;
                source.Play();
                StartCoroutine(Reactivate(11.5f));
                DestroyAreaOne();
                break;
            case 12:
                source.clip = line12;
                source.Play();
                break;
            case 13:
                source.clip = line13;
                source.Play();
                break;
            case 14:
                foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<EnemyStateController>().SetState(new EnemyIdle(enemy.GetComponent<EnemyStateController>()));
                    enemy.GetComponent<NavMeshAgent>().speed = 0;
                    enemy.GetComponent<NavMeshAgent>().acceleration = 0;
                }
                move.SetActive(false);
                turn.SetActive(false);
                source.clip = line14;
                source.Play();
                StartCoroutine(Reactivate(7.1f));
                DestroyAreaTwo();
                break;
            case 15:
                source.clip = line15;
                source.Play();
                break;
            case 16:
                foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<EnemyStateController>().SetState(new EnemyIdle(enemy.GetComponent<EnemyStateController>()));
                    enemy.GetComponent<NavMeshAgent>().speed = 0;
                    enemy.GetComponent<NavMeshAgent>().acceleration = 0;
                }
                move.SetActive(false);
                turn.SetActive(false);
                source.clip = line16;
                source.Play();
                line = 11;
                StartCoroutine(WaitForLine(6.1f));
                break;
            case 18:
                source.clip = line18;
                source.Play();
                DestroyAreaThree();
                break;
            case 19:
                keycardDisplay.SetActive(true);
                move.SetActive(false);
                turn.SetActive(false);
                source.clip = line19;
                source.Play();
                StartCoroutine(Reactivate2(12.1f));
                DestroyAreaFour();
                break;
            case 20:
                source.clip = line20;
                source.Play();
                break;
            case 21:
                source.clip = line21;
                source.Play();
                break;

        }
    }

    public IEnumerator Reactivate(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<NavMeshAgent>().speed = 5;
            enemy.GetComponent<NavMeshAgent>().acceleration = 8;
        }
        source.Stop();
        move.SetActive(true);
        turn.SetActive(true);
    }

    public IEnumerator Reactivate2(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        source.Stop();
        move.SetActive(true);
        turn.SetActive(true);
    }

    private void DestroyAreaZero()
    {
        GameObject[] areaZero = GameObject.FindGameObjectsWithTag("StopArea0");

        foreach (GameObject area in areaZero)
        {
            Destroy(area);
        }
    }

    private void DestroyAreaOne()
    {
        GameObject[] areaOne = GameObject.FindGameObjectsWithTag("StopArea1");

        foreach (GameObject area in areaOne)
        {
            Destroy(area);
        }
    }

    private void DestroyAreaTwo()
    {
        GameObject[] areaTwo = GameObject.FindGameObjectsWithTag("StopArea2");

        foreach (GameObject area in areaTwo)
        {
            Destroy(area);
        }
    }

    private void DestroyAreaThree()
    {
        GameObject[] areaThree = GameObject.FindGameObjectsWithTag("StopArea3");

        foreach (GameObject area in areaThree)
        {
            Destroy(area);
        }
    }

    private void DestroyAreaFour()
    {
        GameObject[] areaFour = GameObject.FindGameObjectsWithTag("StopArea4");

        foreach (GameObject area in areaFour)
        {
            Destroy(area);
        }
    }
}
