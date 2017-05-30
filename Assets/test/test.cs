using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public float speed = 0.01f;
    private Material _material;
    void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        _material.mainTextureOffset = new Vector2(Time.time * speed, 0);
        //GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
    

