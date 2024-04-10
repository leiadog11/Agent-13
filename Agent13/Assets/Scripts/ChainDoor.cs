using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainDoor : MonoBehaviour
{
    public AudioSource source;
    public GameObject voiceLines;
    public ParticleSystem particleSystem;

    private void Start()
    {

    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mop"))
        {
            StartCoroutine(DoStuff());
        }
    }

    IEnumerator DoStuff()
    {
        source.Play();
        voiceLines.GetComponent<VoiceLines>().Lines();
        particleSystem.Play();
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
