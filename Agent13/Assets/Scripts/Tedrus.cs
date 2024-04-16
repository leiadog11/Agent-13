using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Tedrus : XRGrabInteractable
{
    public GameObject gameManager;
    public GameObject player;
    public GameObject torus, text;
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
        if (canRotate)
        {
            gameObject.transform.Rotate(Vector3.up, 15f * Time.deltaTime);

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.GetComponent<GameManager>().tedrus = true;
            StartCoroutine(Collect());
        }
    }

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        base.OnSelectEntering(args);
        gameManager.GetComponent<GameManager>().tedrus = true;
        StartCoroutine(Collect());
    }

    IEnumerator Collect()
    {
        canRotate = false;
        gameObject.GetComponent<ParticleSystem>().Play();
        source.Play();
        torus.SetActive(false);
        text.SetActive(true);
        text.transform.LookAt(player.transform);
        yield return new WaitForSeconds(6);
        text.SetActive(false);
        Destroy(gameObject);
    }
}
