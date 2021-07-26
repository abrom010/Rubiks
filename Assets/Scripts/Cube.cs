using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
    
    // the structure of the cube at the start
    private string[,,] cubicleNames = new string[3, 3, 3] {  // red front white top
        {   // [face][row][column]
            { "FrontTopLeft", "FrontTopMiddle", "FrontTopRight" },
            { "FrontMiddleLeft", "FrontMiddleMiddle", "FrontMiddleRight" },
            { "FrontBottomLeft", "FrontBottomMiddle", "FrontBottomRight" }
        },
        {
            { "CenterTopLeft", "CenterTopMiddle", "CenterTopRight" },
            { "CenterMiddleLeft", "", "CenterMiddleRight" },
            { "CenterBottomLeft", "CenterBottomMiddle", "CenterBottomRight" }
        },
        {
            { "BackTopLeft", "BackTopMiddle", "BackTopRight" },
            { "BackMiddleLeft", "BackMiddleMiddle", "BackMiddleRight" },
            { "BackBottomLeft", "BackBottomMiddle", "BackBottomRight" }
        }
    };

    Dictionary<string, GameObject> children = new Dictionary<string, GameObject>();
    GameObject[,,] cubicles = new GameObject[3,3,3];
    bool rotating = false;
    float startTime;
    float lastRotation;

    void Start() {
        // populating children dictionary with cubicles (using the transform's children)
        foreach (Transform child in transform) {
            children[child.name] = child.gameObject;
        }

        // populate cubicles array3 with cubicles, structured using cubicleNames array3
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                for (int k = 0; k < 3; k++) {
                    if (cubicleNames[i, j, k] == "") break;
                    cubicles[i, j, k] = children[cubicleNames[i, j, k]];
                }
            }
        }
        
        RotateRedFace();
    }

    void Update() {
        if (rotating) {
            InterpolationRotationBro();
        }
    }

    // physically rotate a face
    void InterpolationRotationBro() {
        float currentTime = Time.time;
        float timeDifference = currentTime - startTime;
        if (timeDifference >= 1.0f) {
            rotating = false;
        } else {
            float thisRotation = Mathf.Lerp(0, -90.0f, timeDifference);
            for (int j = 0; j < 3; j++) {
                for (int k = 0; k < 3; k++) {
                    // reset rotation
                    cubicles[0, j, k].transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 0, 1), -lastRotation);

                    // apply new rotation
                    cubicles[0, j, k].transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 0, 1), thisRotation);
                }
            }
            lastRotation = thisRotation;
        }
    }

    // logically rotate face
    void RotateRedFace() {
        // start the physical rotation
        rotating = true;
        startTime = Time.time;

        /* swap the cubicle gameobjects */
        // corners
        GameObject temp = cubicles[0,0,0];
        cubicles[0,0,0] = cubicles[0,2,0];
        cubicles[0,2,0] = cubicles[0,2,2];
        cubicles[0,2,2] = cubicles[0,0,2];
        cubicles[0,0,2] = temp;

        // edges
        temp = cubicles[0,0,1];
        cubicles[0,0,1] = cubicles[0,1,0];
        cubicles[0,1,0] = cubicles[0,2,1];
        cubicles[0,2,1] = cubicles[0,1,2];
        cubicles[0,1,2] = temp;
        /* swap the cubicle gameobjects */

        // rotate the normals
        for (int j = 0; j < 3; j++) {
            for (int k = 0; k < 3; k++) {
                GameObject temp1 = cubicles[0, j, k];
                int amount = temp1.transform.childCount;
                for (int i = 0; i < amount; ++i) {
                    GameObject o = temp1.transform.GetChild(i).gameObject;
                    Face face = o.GetComponent<Face>();
                    face.RotateNormal(new Vector3(0, 0, 90));
                }
            }
        }
           
    }

    void Scramble() {
        
    }

    void GetCenter() {

    }

    void Undo() {

    }

}
