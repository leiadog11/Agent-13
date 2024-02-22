using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardManager : MonoBehaviour
{
    public int amount;
    public GameObject elevatorDoor;
    public GameObject tips;
    public AudioSource keycard;
    public AudioClip unlock;
    public AudioClip get;

    void Start()
    {
        amount = 0;
    }

    public void GainKeyCard()
    {
        keycard.clip = get;
        keycard.Play();
        amount++;

        if(amount == 3)
        {
            keycard.clip = unlock;
            keycard.Play();
            Destroy(elevatorDoor);
            Destroy(tips);
        }
    }
}
