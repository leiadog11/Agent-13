using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerWall : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mop"))
        {
            Destroy(gameObject);
        }
    }
}
