using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public float yOffset;
    public float zOffset;

    private void Start()
    {
        yOffset = 2.2f;
        zOffset = 3.5f;
    }

    void Update()
    {
        Vector3 newPosition = playerTransform.position;

        newPosition.y += yOffset;
        newPosition.z += zOffset;

        transform.position = newPosition;
    }
}
