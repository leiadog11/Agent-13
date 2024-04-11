using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public GameObject keycardDisplay;
    private Transform spawnLoc;
    [SerializeField] private List<Transform> keycardPositions = new List<Transform>();

    public GameObject gameManager;
    public GameObject voiceLines;

    private void Awake()
    {
        amount = 0;
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        keycardDisplay = gameManager.GetComponent<GameManager>().keycardDisplay;
        voiceLines = gameManager.GetComponent<GameManager>().voiceLines;
    }

    void Start()
    {
        amount = 0;
        keycardDisplay.GetComponent<TextMeshProUGUI>().text = amount.ToString();
        spawnLoc = RandomSpawn();
        gameObject.transform.position = spawnLoc.transform.position;
        Instantiate(keycard);
    }

    public void GainKeyCard()
    {
       source.clip = get;
       source.PlayOneShot(get);
        amount++;
        keycardDisplay.GetComponent<TextMeshProUGUI>().text = amount.ToString();
        if (amount >= 1 && gameManager.GetComponent<GameManager>().level == 2)
        {
            voiceLines.GetComponent<VoiceLines>().PlaySpecificLine(20);
            source.clip = unlock;
            source.PlayOneShot(unlock);
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
