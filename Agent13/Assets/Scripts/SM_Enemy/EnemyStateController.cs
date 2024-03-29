using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.Interaction.Toolkit;

public class EnemyStateController : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    public GameObject move;
    public GameObject turn;
    public GameObject combatGrid;
    public GameObject leftSpawn, topSpawn, rightSpawn, bottomSpawn;
    public GameObject leftWarning, topWarning, rightWarning, bottomWarning;
    public GameObject cc;
    public GameObject playerTP;
    public GameObject enemyTP;
    public GameObject invis;
    public EnemyState currentState;
    public NavMeshAgent m_Agent;
    public Material[] materials;
    public LayerMask playerLayer;
    public float raycastDistance = 15f;
    public bool found;
    public bool combat;
    public AudioSource source;
    public AudioClip footsteps;
    public AudioClip hey;
    public AudioClip running;
    public AudioClip enemyHit;
    public AudioClip finalHit;
    [SerializeField] private List<Transform> movePositions = new List<Transform>();


    // Start is called before the first frame update
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        SetState(new EnemyIdle(this));
    }

    // Update is called once per frame
    void Update()
    {
        currentState.CheckTransitions();
        currentState.Act();
    }

    public void SetState(EnemyState es)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }

        currentState = es;

        if (currentState != null)
        {
            currentState.OnStateEnter();
        }
    }
    public Transform RandomDestination()
    {
        if (movePositions.Count > 0)
        {
            int rd = Random.Range(0, movePositions.Count);
            return movePositions[rd];
        }

        return null;
    }

    public void CastRay(Vector3 direction)
    {
        Vector3 raycastOrigin = transform.position + transform.up * 1.5f;
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin, direction, out hit, raycastDistance, playerLayer))
        {
            if (hit.collider.CompareTag("Player"))
            {
                found = true;
            }
        }

        // Debug drawing of rays in the scene view
        Debug.DrawRay(raycastOrigin, direction * raycastDistance, Color.red);
    }

}
