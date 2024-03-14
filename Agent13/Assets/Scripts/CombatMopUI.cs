using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMopUI : MonoBehaviour
{

    // Update is called once per frame
    public Transform targetObject;  // The object to follow
    private float posX = 0.44f, posY = -0.45f, posZ = -0.21f;
    private Vector3 posOffset;

    private float rotX = 23.2f, rotY = 82.9f, rotZ = 2.35f;
    private Quaternion rotOffset;


    private void Start()
    {
        posOffset = new Vector3(posX, posY, posZ);
        rotOffset = Quaternion.Euler(rotX, rotY, rotZ);
    }

    // Update is called once per frame
    void Update()
    {
        if (targetObject != null)
        {
            // Set the follower's position and rotation to match the target object
            transform.position = targetObject.position + posOffset;
            transform.rotation = targetObject.rotation * rotOffset;
        }
    }
}
