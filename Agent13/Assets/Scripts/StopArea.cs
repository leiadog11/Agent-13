using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopArea : MonoBehaviour
{
    public GameObject voiceLines;
    public int number = 0;

    public GameObject gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        voiceLines = gameManager.GetComponent<GameManager>().voiceLines;
    }

    public void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            if (number == 0)
            {
                voiceLines.GetComponent<VoiceLines>().Lines();
            }
            if (number == 1)
            {
                voiceLines.GetComponent<VoiceLines>().PlaySpecificLine(11);
            }
            if (number == 2)
            {
                voiceLines.GetComponent<VoiceLines>().PlaySpecificLine(14);
            }
            if (number == 3)
            {
                voiceLines.GetComponent<VoiceLines>().PlaySpecificLine(18);
            }
            if (number == 4)
            {
                voiceLines.GetComponent<VoiceLines>().PlaySpecificLine(19);
            }
        }
    }
}
