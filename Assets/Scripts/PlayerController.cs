using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D Mybody;
    public float speed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public GameObject GroundCheck;
    Animator anim;
    public TextMeshProUGUI score;
    public float highestPoint;

    public bool isGrounded()
    {
        return Physics2D.Raycast(GroundCheck.transform.position, Vector2.down, 0.5f,groundLayer);
    }
    

    void Start()
    {
        Mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float xvalue = Input.GetAxisRaw("Horizontal");
        Mybody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Mybody.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Mybody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            Debug.Log("Jump");
            
        }

        if (isGrounded())
        {
            anim.SetBool("isjumping", false);
        }
        else if (!isGrounded())
        {
            anim.SetBool("isjumping",true);
        }
        if (xvalue > 0)
        {
            transform.localScale = new Vector3(5.5f, 5.5f, 5.5f);
        }
        else if (xvalue < 0)
        {
            transform.localScale = new Vector3(-5.5f, 5.5f, 5.5f);
        }
        anim.SetBool("Running",xvalue != 0);

        if (transform.position.y >=0)
        {
            highestPoint = MathF.Round(transform.position.y/6.2f);
            score.text = "Highest reached - " + highestPoint;
        }
        else
        {
            score.text = "Highest reached - " + 0;
        }

    }
}
