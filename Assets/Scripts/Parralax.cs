using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    Rigidbody2D Body;
    public GameObject[] layers;
    public float speed = 1f;
    public float distance = 19;
    public float[] layerSpeed;

    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= distance)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        else{
            Body.velocity = new Vector2(speed, 0);
            foreach (GameObject layer in layers)
            {
                Body.velocity = new Vector2(speed, 0);
            }
        }
    }
}
