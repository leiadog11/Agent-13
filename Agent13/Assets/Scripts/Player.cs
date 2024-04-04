using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Vector3 level2TP;
    private Vector3 level3TP;
    public GameObject button;
    public GameObject realPlayer;

    // Start is called before the first frame update
    void Start()
    {
        level2TP = new Vector3(-2.61f, 3.74f, -61.93f);
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            realPlayer.transform.position = level2TP;
        }

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            //realPlayer.transform.position = level3TP.position;
        }
    }

    // Unsubscribe from the sceneLoaded event when the script is disabled or destroyed
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
