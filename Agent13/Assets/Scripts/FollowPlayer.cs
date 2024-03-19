using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = playerTransform.position;

        // Add the Y offset
        newPosition.y += 9;

        // Set the object's position
        transform.position = newPosition;
    }
}
