using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public int deaths = 0;
    public void RestartButton()
    {
        deaths++;
        SceneManager.LoadScene("Gameplay");
    }
}
