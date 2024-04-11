using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public TextMeshProUGUI amt;
    public int health;
    public bool lose;
    public GameObject player;
    public GameObject mop;
    public GameObject gameManager;
    public GameObject gameOver;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 25;
        lose = false;
    }

    // Update is called once per frame
    void Update()
    {
        amt.GetComponent<TextMeshProUGUI>().text = health.ToString();
    }

    public void LoseHealth()
    {
        if(gameManager.GetComponent<GameManager>().attacked >= 1)
        {
            health -= 5;

            if (health <= 0)
            {
                lose = true;
                StartCoroutine(Lose());
            }
        }
    }

    IEnumerator Lose()
    {
        gameOver.SetActive(true);
        yield return new WaitForSeconds(2.2f);
        Destroy(player);
        Destroy(mop);
        Destroy(gameManager);
        SceneManager.LoadScene("Menu");
    }
}
