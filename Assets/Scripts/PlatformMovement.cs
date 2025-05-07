using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private float speed;
    Rigidbody2D Mybody;
    private float DestroyDelay = -20f;

    private void Start() 
    {
        Mybody = GetComponent<Rigidbody2D>();
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void Update()
    {
        // Move forward constantly at the set speed
        Mybody.velocity = new Vector2(speed * -1, Mybody.velocity.y);
        if (transform.position.x <= DestroyDelay)
        {
            Destroy(gameObject);
        }
    }
}
