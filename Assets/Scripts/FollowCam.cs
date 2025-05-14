using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowCam : MonoBehaviour
{
    public Transform player;             // 👀 Player reference
    private float highestY;              // 🔝 Highest Y the camera has reached
    private Camera mainCamera;           // 🎥 Camera reference

    void Start()
    {
        // ✅ Auto-find player if not assigned
        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
                Debug.LogError("Player not found! Tag your player as 'Player'.");
            }
        }

        highestY = transform.position.y;
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        if (player == null) return;
        Vector3 cameraPos = transform.position;
        if (player.position.y > highestY)
        {
            highestY = player.position.y;
            cameraPos.y = highestY;
            transform.position = cameraPos;
        }

        Vector3 screenPoint = mainCamera.WorldToViewportPoint(player.position);
        if (screenPoint.y < 0)
        {
            Debug.Log("Player fell out of camera view and died!");
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        
        Destroy(player.gameObject); 
        SceneManager.LoadScene(2);
        
    }
}
