using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Jorb : XRGrabInteractable
{
    public GameObject gameManager;
    public GameObject player;
    public GameObject sphere, text;
    private AudioSource source;
    private bool canRotate;

    // Start is called before the first frame update
    void Start()
    {
        canRotate = true;
        source = GetComponent<AudioSource>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        player = gameManager.GetComponent<GameManager>().player;
    }

    // Update is called once per frame
    void Update()
    {
        if(canRotate)
        {
            gameObject.transform.Rotate(Vector3.up, 15f * Time.deltaTime);

        }
    }

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        base.OnSelectEntering(args);
        gameManager.GetComponent<GameManager>().jorb = true;
        StartCoroutine(Collect());
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager.GetComponent<GameManager>().jorb = true;
            StartCoroutine(Collect());
        }
    }

    IEnumerator Collect()
    {
        canRotate = false;
        gameObject.GetComponent<ParticleSystem>().Play();
        source.Play();
        sphere.SetActive(false);
        text.SetActive(true);
        text.transform.LookAt(player.transform);
        yield return new WaitForSeconds(6);
        text.SetActive(false);
        Destroy(gameObject);
    }
}
