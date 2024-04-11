using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerWall : MonoBehaviour
{
    public AudioSource source;
    public GameObject voiceLines;
    public GameObject effect;
    public GameObject gameManager;
    //public int place = 0;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
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
        /*
        if(gameManager.GetComponent<GameManager>().level == 1)
        {
            if (place == 1)
            {
                effect.transform.position = new Vector3(-26.3f, 97.5f, 3.9f);
            }
            else if (place == 2)
            {
                effect.transform.position = new Vector3(-8.3f, 97.8f, 34f);
            }
            else if (place == 3)
            {
                effect.transform.position = new Vector3(-72.9f, 97.8f, 0.35f);
            }
        }
        */
        effect.transform.position = gameObject.transform.position;
        source.Play();
        //voiceLines.GetComponent<VoiceLines>().Lines();
        effect.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
