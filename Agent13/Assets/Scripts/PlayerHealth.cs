using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    }

    // Update is called once per frame
    void Update()
    {
        amt.GetComponent<TextMeshPro>().text = health.ToString();
    }

    public void LoseHealth()
    {
        health -= 5;

        if(health <= 0)
        {
            lose = true;
            StartCoroutine(Lose());   
        }
    }

    IEnumerator Lose()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Menu");
    }
}
