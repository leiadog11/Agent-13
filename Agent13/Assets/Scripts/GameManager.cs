using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject playerHealth;
    public GameObject keycardDisplay;
    public GameObject voiceLines;
    public GameObject mop;
    public GameObject move;
    public GameObject turn;
    public GameObject invis;

    public int level;
    public int attacked;
    public bool jorb, ellertsamid, tedrus;

    public void Awake()
    {
        attacked = 0;
        level = 1;
        jorb = ellertsamid = tedrus = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
