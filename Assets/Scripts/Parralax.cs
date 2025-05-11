using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    Material mat;
    float distance;

    [Range(0,1)]
    public float speed = 1f;

    private void Start() {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        distance += Time.deltaTime * speed;
        mat.SetTextureOffset("_MainTex",Vector2.right * distance);  
    }
}
