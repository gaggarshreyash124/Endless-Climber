using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject spawnerPrefab;           // Prefab for spawners
    public Transform player;                   // Reference to player
    public int numSpawnersAbove = 3;           // Minimum number of spawners above the player
    public float spawnIncrement = 3f;          // Increment value for spawning spawners
    private float highestPointReached = 0f;    // Track the highest point spawners have been spawned at
    private float lastSpawnedY = 0f;           // Track the Y value of the last spawned spawner

    void Start()
    {
        if (player == null)
        {
            // Auto-find the player by tag if not assigned
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
                Debug.LogError("Player not found! Make sure your player is tagged 'Player'.");
            }
        }
        
        // Initially set the last spawned Y to the player’s starting position
        lastSpawnedY = player.position.y;
        highestPointReached = lastSpawnedY;

    }

    void Update()
    {
        // Ensure that the spawners above the player are always at least the required number
        EnsureSpawnersAbovePlayer();
    }

    // Method to ensure there are always at least numSpawnersAbove spawners above the player
    private void EnsureSpawnersAbovePlayer()
    {
        // Calculate the Y position of the last spawned spawner
        float playerY = player.position.y;
        float targetHeight = playerY + spawnIncrement * numSpawnersAbove;

        // Check if we need to spawn more spawners to keep the required number above the player
        if (targetHeight > highestPointReached)
        {
            // Spawn more spawners until we have the required number above the player
            while (highestPointReached < targetHeight)
            {
                highestPointReached += spawnIncrement;
                SpawnSpawner(highestPointReached);
            }
        }
    }

    // Method to spawn a new spawner at the specified Y position
    private void SpawnSpawner(float spawnY)
    {
        // Create the spawner at the calculated position
        Vector3 spawnPos = new Vector3(transform.position.x + Random.Range(-8,8), spawnY, 0f);
        Instantiate(spawnerPrefab, spawnPos, Quaternion.identity);
    }
}
