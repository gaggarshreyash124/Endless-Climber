using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnInterval = 3;
    public float objectSpeed;
    private Transform playerTransform;

    public float deactivateHeight; 

    private void Start()
    {
        
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player not found! Make sure your player is tagged 'Player'.");
        }

        objectSpeed = 3.5f;
        InvokeRepeating(nameof(SpawnObject), 0f, spawnInterval);
        deactivateHeight = transform.position.y + 20;
        
    }

    private void Update()
    {
        // ✅ Check if player reached the deactivation height
        if (playerTransform != null && playerTransform.position.y >= deactivateHeight)
        {
            Debug.Log("Player reached height of " + deactivateHeight + ". Spawner is being destroyed.");
            Destroy(gameObject); 
        }
    }

    public void SpawnObject()
    {
        
        GameObject spawned = Instantiate(objectToSpawn, transform.position, transform.rotation);

        PlatformMovement movable = spawned.GetComponent<PlatformMovement>();
        if (movable != null)
        {
            movable.SetSpeed(objectSpeed);
        }
        else
        {
            Debug.LogWarning("No PlatformMovement script found on spawned object.");
        }
    }
}
