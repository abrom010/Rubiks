using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubicle : MonoBehaviour    //Unity object inheritance to give Cubicle some Unity usable properties
{
    enum Type { corner, edge, center };

    [SerializeField] Type cubicleType;  //lets Unity serialize "cubicleType" variable of Type type even though its only in Cubicle?
    GameObject[] faces; //array of faces in the cubicle object

    void Start()
    {
        if (cubicleType == Type.corner) //set size of faces array based on type of cubicle
            faces = new GameObject[3];
        else if (cubicleType == Type.edge)
            faces = new GameObject[2];
        else
            faces = new GameObject[1];

        // faces.Length works too (without human error) vvv
        int amount = transform.childCount;  //"The number of children the parent Transform has." parent Transform is separate obj from parent Cube? wont this be the same as faces.Length? or GameObject contains no length getting option?
        for (int i = 0; i < amount; ++i)
            faces[i] = transform.GetChild(i).gameObject;    //gets Cubicle's children objects and stores value in faces array

    }
}
