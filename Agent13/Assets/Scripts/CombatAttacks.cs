using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class CombatAttacks : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public GameObject player;
    public int way;
    private bool dead;
    public AudioSource source;
    public AudioClip block;
    public AudioClip hit;

    private void Start()
    {

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
            source.Play();
            dead = true;
        }
        else if (ob.GetComponent<Attacks>().result == 1)
        {
            source.clip = hit;
            source.Play();
            //player.health - 5
            dead = true;
        }
    }
}
