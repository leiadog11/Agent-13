using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Invisible : MonoBehaviour
{
    public bool invisible = false;
    public float inactivityThreshold = 1.5f; 
    private float timeSinceLastMovement = 0f;
    private Vector3 lastPosition;

    void Start()
    {
        invisible = false;
        lastPosition = transform.position;
    }

 

    void Update()
    {
        Vector3 currentPosition = transform.position;

        float distanceMoved = Vector3.Distance(lastPosition, currentPosition);

        if (distanceMoved > 0.001f)
        {
            invisible = false;
            timeSinceLastMovement = 0f;
        }
        else
        {
            timeSinceLastMovement += Time.deltaTime;
            if (timeSinceLastMovement >= inactivityThreshold)
            {
                invisible = true;
            }
        }

        lastPosition = currentPosition;
    }
}
