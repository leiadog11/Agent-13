using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class CombatAttacks : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public GameObject health;
    public int way;
    private bool dead;
    public AudioSource source;
    public AudioClip block;
    public AudioClip hit;

    public GameObject gameManager;

    public void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        health = gameManager.GetComponent<GameManager>().playerHealth;
    }

    private void Start()
    {
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        dead = false;
        GameObject spawnedObject = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        spawnedObject.GetComponent<Attacks>().theWay = way;

        // Make the spawned object a child of the spawner
        if (spawnedObject != null)
            spawnedObject.transform.parent = transform;  

        StartCoroutine(WaitForDeath(spawnedObject));
    }

    private IEnumerator WaitForDeath(GameObject ob)
    {
        yield return new WaitForSeconds(0.2f);
        DeathCheck(ob);
        yield return new WaitForSeconds(0.2f);
        DeathCheck(ob);
        yield return new WaitForSeconds(0.2f);
        DeathCheck(ob);
        yield return new WaitForSeconds(0.2f);
        DeathCheck(ob);
        yield return new WaitForSeconds(0.2f);
        DeathCheck(ob);
        yield return new WaitForSeconds(0.2f);
        DeathCheck(ob);
        yield return new WaitForSeconds(0.2f);
        DeathCheck(ob);
        yield return new WaitForSeconds(0.2f);
        DeathCheck(ob);
    }

    private void DeathCheck(GameObject ob)
    {
        if (ob.GetComponent<Attacks>().result == 2)
        {
            source.clip = block;
            source.PlayOneShot(block);
            dead = true;
        }
        else if (ob.GetComponent<Attacks>().result == 1)
        {
            source.clip = hit;
            source.PlayOneShot(hit);
            health.GetComponent<PlayerHealth>().LoseHealth();
            dead = true;
        }
    }
}
