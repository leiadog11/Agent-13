using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAttacks : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject prefabToSpawn;
    public float spawnDelay = 2f;
    public float objectLifetime = 5f; // Maximum time before the instantiated object is destroyed

    private float timer = 0f;

    private void Start()
    {
        int layerToIgnoreIndex = LayerMask.NameToLayer("Wall");
        Physics.IgnoreLayerCollision(gameObject.layer, layerToIgnoreIndex);
    }

    // Update is called once per frame
    void Update()
    {
        // Countdown the timer
        timer -= Time.deltaTime;

        // Spawn the prefab every 2 seconds
        if (timer <= 0f)
        {
            GameObject spawnedObject = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);

            // Make the spawned object a child of the spawner
            if (spawnedObject != null)
                spawnedObject.transform.parent = transform;

            Destroy(spawnedObject, objectLifetime); // Destroy the instantiated object after objectLifetime seconds

            // Move the spawned object on the X-axis
            StartCoroutine(MoveObject(spawnedObject, Vector3.right));

            timer = spawnDelay;
        }
    }

    // Coroutine to move the spawned object
    private IEnumerator MoveObject(GameObject obj, Vector3 direction)
    {
        float elapsedTime = 0f;
        float duration = objectLifetime;

        while (elapsedTime < duration)
        {
            obj.transform.Translate(direction * moveSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
