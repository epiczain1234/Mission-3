using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnPress : MonoBehaviour
{
    // Start is called before the first frame update
    public Material material;
    public Color newColor;
    public KeyCode modifyColor;
    void Start()
    {
        material.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(modifyColor))
            if (material.color == Color.black){
                material.color = newColor;

            }
            else{
                material.color = Color.black;
            }
    }
}
