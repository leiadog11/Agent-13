using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HostageSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnLocations = new List<Transform>();
    [SerializeField] private GameObject hostagePrefab; // The prefab you want to spawn

    // Start is called before the first frame update
    void Start()
    {
        Transform randomSpawnPoint = RandomSpawn();
        Instantiate(hostagePrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform RandomSpawn()
    {
        if (spawnLocations.Count > 0)
        {
            int rd = Random.Range(0, spawnLocations.Count);
            return spawnLocations[rd];
        }

        return null;
    }
}
