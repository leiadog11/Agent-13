using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAttacks : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject prefabToSpawn;
    public GameObject spawnedObject;
    public GameObject player;
    public AudioSource source;
    public AudioClip block;
    public AudioClip hit;
    public float objectLifetime = 5f; // Maximum time before the instantiated object is destroyed
    public float way;

    private float timer = 0f;

    private void Start()
    {
        int layerToIgnoreIndex = LayerMask.NameToLayer("Wall");
        Physics.IgnoreLayerCollision(gameObject.layer, layerToIgnoreIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        spawnedObject = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        

        // Make the spawned object a child of the spawner
        if (spawnedObject != null)
            spawnedObject.transform.parent = transform;

        // Move the spawned object on the X-axis
        if (way == 1)
        {
            StartCoroutine(MoveObject(spawnedObject, Vector3.right));
        }
        else if (way == 2)
        {
            StartCoroutine(MoveObject(spawnedObject, Vector3.down));
        }
        else if (way == 3)
        {
            StartCoroutine(MoveObject(spawnedObject, Vector3.left));
        }
        else if (way == 4)
        {
            StartCoroutine(MoveObject(spawnedObject, Vector3.up));
        }
    }

    // Coroutine to move the spawned object
    private IEnumerator MoveObject(GameObject obj, Vector3 direction)
    {
        float elapsedTime = 0f;
        float duration = objectLifetime;

        while (elapsedTime < duration)
        {
            obj.transform.Translate((way * direction) * moveSpeed * Time.deltaTime);
            if (spawnedObject.GetComponent<Attacks>().result == 0)
            {
                source.clip = block;
                source.Play();
               Destroy(spawnedObject);
            }
            else if (spawnedObject.GetComponent<Attacks>().result == 1)
            {
                source.clip = hit;
                source.Play();
                //player.health - 5
                Destroy(spawnedObject);
            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
