using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour   //Unity object inheritance to give Cube some Unity usable properties
{
    private string[,,] cubicleNames = new string[3, 3, 3]   //defined facing red with white up top
    {
        {
            { "FrontTopLeft", "FrontTopMiddle", "FrontTopRight" },
            { "FrontMiddleLeft", "FrontMiddleMiddle", "FrontMiddleRight" },
            { "FrontBottomLeft", "FrontBottomMiddle", "FrontBottomRight" }
        },
        {
            { "CenterTopLeft", "CenterTopMiddle", "CenterTopRight" },
            { "CenterMiddleLeft", "NULL", "CenterMiddleRight" },
            { "CenterBottomLeft", "CenterBottomMiddle", "CenterBottomRight" }
        },
        {
            { "BackTopLeft", "BackTopMiddle", "BackTopRight" },
            { "BackMiddleLeft", "BackMiddleMiddle", "BackMiddleRight" },
            { "BackBottomLeft", "BackBottomMiddle", "BackBottomRight" }
        }
    };

    Dictionary<string, GameObject> children = new Dictionary<string, GameObject>(); //to tie a cubicleName to a cubicle GameObject
    GameObject[,,] cubicles = new GameObject[3,3,3];    //3d array to represent cubicles as GameObjects

    void Start()
    {
        foreach (Transform child in transform)  //looking through every child object of cube to see if it has a Transorm? sets cubicle (child is only cubicle in this case? does it include Face?) value in dict to be cubicle gameObject. what is "transform" in this line?
            children[child.name] = child.gameObject;

        // ^^ in transform <- this transform is in the current gameObject (the rubiks cube). Going through all of the children of this gameObject's transform.
            
        for (int i = 0; i < 3; i++) //gets GameObject from "children" dictionary and assigns that GameObject value to also be value in "cubicles" array
            for (int j = 0; j < 3; j++)
                for (int k = 0; k < 3; k++)
                {
                    if (cubicleNames[i, j, k] == "") break;
                    cubicles[i, j, k] = children[cubicleNames[i, j, k]];
                }
    }

    void Update()
    {
        // rotating a face physically
        for(int j = 0; j < 3; j++)  //what is this and why?
            for (int k = 0; k < 3; k++)
                cubicles[0, j, k].transform.RotateAround(new Vector3(0,0,0), new Vector3(0,0,1),Time.deltaTime * 100f);
    }

    void Scramble()
    {
        
    }

    void Undo()
    {

    }

    void RotateFace()
    {

    }


}
