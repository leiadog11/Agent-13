using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyCardManager : MonoBehaviour
{
    public int amount;
    public AudioSource source;
    public AudioClip unlock;
    public AudioClip get;
    public GameObject keycard;
    public GameObject elevator;
    private Transform spawnLoc;
    [SerializeField] private List<Transform> keycardPositions = new List<Transform>();

    void Start()
    {
        amount = 0;
        spawnLoc = RandomSpawn();
        gameObject.transform.position = spawnLoc.transform.position;
        Instantiate(keycard);
    }

    public void GainKeyCard()
    {
       // source.clip = get;
       // source.PlayOneShot(get);
        amount++;
        if(amount >= 1 /*&& scene = 2 */)
        {
            elevator.GetComponent<Elevator>().ElevatorOpen();   
        }
    }

    public Transform RandomSpawn()
    {
        if (keycardPositions.Count > 0)
        {
            int rd = Random.Range(0, keycardPositions.Count);
            return keycardPositions[rd];
        }

        return null;
    }

}
