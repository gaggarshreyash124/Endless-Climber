using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D Mybody;
    public float speed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public GameObject GroundCheck;

    public bool isGrounded()
    {
        return Physics2D.Raycast(GroundCheck.transform.position, Vector2.down, 0.5f,groundLayer);
    }
    

    void Start()
    {
        Mybody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Mybody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Mybody.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Mybody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            Debug.Log("Jump");
        }
    }
}
