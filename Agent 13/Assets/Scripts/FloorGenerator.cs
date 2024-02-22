using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    public GameObject[] roomPrefabs; // Array of room prefabs
    public int gridSizeX = 10; // Grid size on X-axis
    public int gridSizeZ = 10; // Grid size on Z-axis
    public GameObject elevatorPrefab; // Elevator prefab

    void Start()
    {
        GenerateFloor();
    }

    void GenerateFloor()
    {
        // Instantiate rooms on the grid
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int z = 0; z < gridSizeZ; z++)
            {
                GameObject roomPrefab = GetRandomRoomPrefab();
                Instantiate(roomPrefab, new Vector3(x * 10, 0, z * 10), Quaternion.identity);
            }
        }

        // Add elevator at the start and end positions
        Instantiate(elevatorPrefab, new Vector3(0, 0, 0), Quaternion.identity); // Start elevator
        Instantiate(elevatorPrefab, new Vector3((gridSizeX - 1) * 10, 0, (gridSizeZ - 1) * 10), Quaternion.identity); // End elevator
    }

    GameObject GetRandomRoomPrefab()
    {
        // Logic to get a random room prefab from the provided array
        return roomPrefabs[Random.Range(0, roomPrefabs.Length)];
    }
}