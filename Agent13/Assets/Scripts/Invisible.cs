using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Invisible : MonoBehaviour
{
    public bool invisible = false;
    private float inactivityThreshold = .75f; 
    private float timeSinceLastMovement = 0f;
    private Vector3 lastPosition;
    public GameObject invis;

    void Start()
    {
        invisible = false;
        lastPosition = transform.position;
    }

 

    void Update()
    {
        Vector3 currentPosition = transform.position;

        float distanceMoved = Vector3.Distance(lastPosition, currentPosition);

        if (distanceMoved > 0.05f)
        {
            invis.GetComponent<Animator>().SetBool("Hidden", false);
            invisible = false;
            timeSinceLastMovement = 0f;
        }
        else
        {
            timeSinceLastMovement += Time.deltaTime;
            if (timeSinceLastMovement >= inactivityThreshold)
            {
                invis.GetComponent<Animator>().SetBool("Hidden", true);
                invisible = true;
            }
        }

        lastPosition = currentPosition;
    }
}
