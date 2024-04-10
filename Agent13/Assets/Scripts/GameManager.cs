using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject playerHealth;
    public GameObject mop;
    public GameObject move;
    public GameObject turn;
    public GameObject invis;

    public int level;

    public void Awake()
    {
        level = 1;
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
