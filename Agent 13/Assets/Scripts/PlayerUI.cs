using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public GameObject hidden;
    public GameObject visible;
    public GameObject win;
    public GameObject lose;
    public GameObject player;
    public GameObject restart;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        hidden.SetActive(false);
        visible.SetActive(false);
        win.SetActive(false);
        lose.SetActive(false);
        restart.SetActive(false);
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver)
        {
            if (player.GetComponent<Invisible>().invisible)
            {
                hidden.SetActive(true);
                visible.SetActive(false);
            }
            else
            {
                hidden.SetActive(false);
                visible.SetActive(true);
            }
        }
    }
}
