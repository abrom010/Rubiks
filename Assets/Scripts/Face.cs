using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour   //Unity object inheritance to give Face some Unity usable properties
{
    enum Color { white, yellow, red, orange, green, blue }; //create enumerator with all 6 colors to perform more actions than if it were strings

    [SerializeField] Color color;   //lets Unity serialize "color" variable of Color type even though its only in Faces?
    Vector3 normal; //each face will have a 3D vector that points perpendicular to the plane the Face is on in order to tie orientation of the faces on each cubicle
    

    void Start()
    {
        switch(color)
        {
            case Color.white:   //white is Top which is on XZ plane so normal points in positive Y direction right?
                normal = new Vector3(0, 1, 0);
                break;
            case Color.yellow:
                normal = new Vector3(0, -1, 0); //down
                break;
            case Color.red:
                normal = new Vector3(0, 0, -1); //front
                break;
            case Color.orange:
                normal = new Vector3(0, 0, 1);  //back
                break;
            case Color.green:
                normal = new Vector3(-1, 0, 0); //left
                break;
            case Color.blue:
                normal = new Vector3(1, 1, 0);  //right
                break;
        }
    }
}
