using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HostageStateController : MonoBehaviour
{
    public GameObject player;
    public HostageState currentState;
    public NavMeshAgent m_Agent;
    public GameObject playerUI;
    public GameObject goal;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerUI = GameObject.FindGameObjectWithTag("PlayerUI");
        goal = GameObject.FindGameObjectWithTag("Goal");
        m_Agent = GetComponent<NavMeshAgent>();
        SetState(new HostageWait(this));
    }

    // Update is called once per frame
    void Update()
    {
        currentState.CheckTransitions();
        currentState.Act();
    }

    public void SetState(HostageState hs)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }

        currentState = hs;

        if (currentState != null)
        {
            currentState.OnStateEnter();
        }
    }
}
