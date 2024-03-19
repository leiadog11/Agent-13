using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{

    public int result;
    // Called when the spawned object collides with another object
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Block"))
        {
            result = 0; //blocked
        }
        if (coll.gameObject.CompareTag("HitBox"))
        {
            result = 1; //damage
        }
    }
}
