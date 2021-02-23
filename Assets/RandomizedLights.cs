using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RandomizedLights : MonoBehaviour
{   
    
    [SerializeField] public Material material;
    public Color newColor;
    public KeyCode modifyColor;
    private System.Random r = new System.Random();
    
    public float count = 0.0f;
    void Start()
    {
        material.color = Color.green;

    }

    // Update is called once per frame
    void Update()
    {
        Invoke("ChangeColorToRed", r.Next(1, 4));
    }

    public void ChangeColorToRed(){
        material.color = Color.blue;
    }
}
