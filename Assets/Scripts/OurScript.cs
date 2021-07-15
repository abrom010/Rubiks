using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OurScript : MonoBehaviour
{
    void Start()
    {
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                for (int k = -1; k < 2; k++)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Transform t = cube.GetComponent<Transform>();
                    t.position = new Vector3(i, j, k);
                    float s = 0.97f;
                    t.localScale = new Vector3(s, s, s);
                    cube.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1);
                }
            }
        }
        
    }

    
    void Update()
    {
        
    }
}
