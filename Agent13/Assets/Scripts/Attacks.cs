using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    // Called when the spawned object collides with another object
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Block"))
        {
            // If collided object has the tag "Block," destroy the spawned object
            Destroy(gameObject);
        }
    }
}
