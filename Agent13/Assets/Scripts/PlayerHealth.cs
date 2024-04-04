using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject amt;
    public int health;
    public bool lose;


    // Start is called before the first frame update
    void Start()
    {
        health = 25;
        lose = false;
        amt.GetComponent<TextMeshPro>().text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseHealth()
    {
        health -= 5;

        if(health <= 0)
        {
            lose = true;
        }
    }
}
