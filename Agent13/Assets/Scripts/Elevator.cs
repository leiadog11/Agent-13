using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private Animator anim;
    public GameObject button;
    public bool isStart;

    public GameObject gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        if (gameManager.GetComponent<GameManager>().level == 1)
        {
            //play elevator ding
            anim.Play("ElevatorOpen");
        }

        if (gameManager.GetComponent<GameManager>().level == 2 && isStart)
        {
            anim.Play("ElevatorOpen");
        }
        else if (gameManager.GetComponent<GameManager>().level == 2)
        {
            anim.Play("ElevatorClose");
        }

        if (gameManager.GetComponent<GameManager>().level == 3 && isStart)
        {
            anim.Play("ElevatorOpen");
        }
        else if (gameManager.GetComponent<GameManager>().level == 3)
        {
            anim.Play("ElevatorClose");
        }

    }

    public void ElevatorOpen()
    {
        anim.Play("ElevatorOpen");
    }

    public void ElevatorClose()
    {
        anim.Play("ElevatorClose");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
