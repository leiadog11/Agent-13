using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerWall : MonoBehaviour
{
    public AudioSource pop;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mop"))
        {
            pop.Play();
            Destroy(gameObject);
        }
    }
}
