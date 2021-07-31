using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
    Dictionary<string, GameObject> children = new Dictionary<string, GameObject>();
    GameObject[,,] cubicles = new GameObject[3,3,3];

    bool rotating = false;
    float startTime;
    float lastRotation;
    Face.Color rotatingSide;
    float degreesToRotate;
    float startingRotation;

    void Start() {
        // populating children dictionary with cubicles (using the transform's children)
        foreach (Transform child in transform) {
            children[child.name] = child.gameObject;
        }

        // populate cubicles array3 with cubicles, structured using cubicleNames array3
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                for (int k = 0; k < 3; k++) {
                    if (CubeData.cubicleNames[i, j, k] == "") break;
                    cubicles[i, j, k] = children[CubeData.cubicleNames[i, j, k]];
                }
            }
        }
    }

    void Update() {
        if (!rotating) {
            if (Input.GetKeyDown(KeyCode.R)) {
                StartRotation(90.0f, Face.Color.red);
            } else if (Input.GetKeyDown(KeyCode.O)) {
                StartRotation(90.0f, Face.Color.orange);
            } else if (Input.GetKeyDown(KeyCode.G)) {
                StartRotation(90.0f, Face.Color.green);
            } else if (Input.GetKeyDown(KeyCode.B)) {
                StartRotation(90.0f, Face.Color.blue);
            } else if (Input.GetKeyDown(KeyCode.W)) {
                StartRotation(90.0f, Face.Color.white);
            } else if (Input.GetKeyDown(KeyCode.Y)) {
                StartRotation(90.0f, Face.Color.yellow);
            }
        } else {
            InterpolationRotationBro(degreesToRotate, rotatingSide);
        }
    }

    Vector3Int[,] GetSideOfColor(Face.Color color) {
        switch(color) {
            case Face.Color.red:
                return CubeData.redSide;
            case Face.Color.orange:
                return CubeData.orangeSide;
            case Face.Color.green:
                return CubeData.greenSide;
            case Face.Color.blue:
                return CubeData.blueSide;
            case Face.Color.white:
                return CubeData.whiteSide;
            case Face.Color.yellow:
                return CubeData.yellowSide;
            default:
                return null;
        }
    }

    // logically rotate face
    void RotateRedFace(bool clockwise) {
        /* swap the cubicle gameobjects */
        // corners
        if (clockwise) {
            GameObject temp = cubicles[0, 0, 0];
            cubicles[0, 0, 0] = cubicles[0, 2, 0];
            cubicles[0, 2, 0] = cubicles[0, 2, 2];
            cubicles[0, 2, 2] = cubicles[0, 0, 2];
            cubicles[0, 0, 2] = temp;

            // edges
            temp = cubicles[0, 0, 1];
            cubicles[0, 0, 1] = cubicles[0, 1, 0];
            cubicles[0, 1, 0] = cubicles[0, 2, 1];
            cubicles[0, 2, 1] = cubicles[0, 1, 2];
            cubicles[0, 1, 2] = temp;

            /* swap the cubicle gameobjects */

            // rotate the normals
            for (int j = 0; j < 3; j++) {
                for (int k = 0; k < 3; k++) {
                    GameObject cubicle = cubicles[0, j, k];
                    int amount = cubicle.transform.childCount;
                    for (int i = 0; i < amount; ++i) {
                        GameObject o = cubicle.transform.GetChild(i).gameObject;
                        Face face = o.GetComponent<Face>();
                        face.RotateNormal(new Vector3(0, 0, 90));
                    }
                }
            }
        }
        else {
            GameObject temp = cubicles[0, 0, 0];
            cubicles[0, 0, 0] = cubicles[0, 0, 2];
            cubicles[0, 0, 2] = cubicles[0, 2, 2];
            cubicles[0, 2, 2] = cubicles[0, 2, 0];
            cubicles[0, 2, 0] = temp;

            // edges
            temp = cubicles[0, 0, 1];
            cubicles[0, 0, 1] = cubicles[0, 1, 2];
            cubicles[0, 1, 2] = cubicles[0, 2, 1];
            cubicles[0, 2, 1] = cubicles[0, 1, 0];
            cubicles[0, 1, 0] = temp;

            /* swap the cubicle gameobjects */

            // rotate the normals
            for (int j = 0; j < 3; j++) {
                for (int k = 0; k < 3; k++) {
                    GameObject cubicle = cubicles[0, j, k];
                    int amount = cubicle.transform.childCount;
                    for (int i = 0; i < amount; ++i) {
                        GameObject o = cubicle.transform.GetChild(i).gameObject;
                        Face face = o.GetComponent<Face>();
                        face.RotateNormal(new Vector3(0, 0, -90));
                    }
                }
            }
        }

        
    }

    void RotateOrangeFace(bool clockwise) {
        /* swap the cubicle gameobjects */
        // corners
        if (clockwise) {
            GameObject temp = cubicles[2, 0, 0];
            cubicles[2, 0, 0] = cubicles[2, 2, 0];
            cubicles[2, 2, 0] = cubicles[2, 2, 2];
            cubicles[2, 2, 2] = cubicles[2, 0, 2];
            cubicles[2, 0, 2] = temp;

            // edges
            temp = cubicles[2, 0, 1];
            cubicles[2, 0, 1] = cubicles[2, 1, 0];
            cubicles[2, 1, 0] = cubicles[2, 2, 1];
            cubicles[2, 2, 1] = cubicles[2, 1, 2];
            cubicles[2, 1, 2] = temp;

            /* swap the cubicle gameobjects */

            // rotate the normals
            for (int j = 0; j < 3; j++) {
                for (int k = 0; k < 3; k++) {
                    GameObject cubicle = cubicles[0, j, k];
                    int amount = cubicle.transform.childCount;
                    for (int i = 0; i < amount; ++i) {
                        GameObject o = cubicle.transform.GetChild(i).gameObject;
                        Face face = o.GetComponent<Face>();
                        face.RotateNormal(new Vector3(0, 0, 90));
                    }
                }
            }
        } else {
            GameObject temp = cubicles[2, 0, 0];
            cubicles[2, 0, 0] = cubicles[2, 0, 2];
            cubicles[2, 0, 2] = cubicles[2, 2, 2];
            cubicles[2, 2, 2] = cubicles[2, 2, 0];
            cubicles[2, 2, 0] = temp;

            // edges
            temp = cubicles[2, 0, 1];
            cubicles[2, 0, 1] = cubicles[2, 1, 2];
            cubicles[2, 1, 2] = cubicles[2, 2, 1];
            cubicles[2, 2, 1] = cubicles[2, 1, 0];
            cubicles[2, 1, 0] = temp;

            /* swap the cubicle gameobjects */

            // rotate the normals
            for (int j = 0; j < 3; j++) {
                for (int k = 0; k < 3; k++) {
                    GameObject cubicle = cubicles[0, j, k];
                    int amount = cubicle.transform.childCount;
                    for (int i = 0; i < amount; ++i) {
                        GameObject o = cubicle.transform.GetChild(i).gameObject;
                        Face face = o.GetComponent<Face>();
                        face.RotateNormal(new Vector3(0, 0, -90));
                    }
                }
            }
        }

    }

    void RotateGreenFace(bool clockwise) {
        /* swap the cubicle gameobjects */
        // corners
        if (clockwise) {
            GameObject temp = cubicles[0, 0, 0];
            cubicles[0, 0, 0] = cubicles[2, 0, 0];
            cubicles[2, 0, 0] = cubicles[2, 2, 0];
            cubicles[2, 2, 0] = cubicles[2, 0, 0];
            cubicles[2, 0, 0] = temp;

            // edges
            temp = cubicles[2, 0, 1];
            cubicles[2, 0, 1] = cubicles[2, 1, 0];
            cubicles[2, 1, 0] = cubicles[2, 2, 1];
            cubicles[2, 2, 1] = cubicles[2, 1, 2];
            cubicles[2, 1, 2] = temp;

            /* swap the cubicle gameobjects */

            // rotate the normals
            for (int j = 0; j < 3; j++) {
                for (int k = 0; k < 3; k++) {
                    GameObject cubicle = cubicles[0, j, k];
                    int amount = cubicle.transform.childCount;
                    for (int i = 0; i < amount; ++i) {
                        GameObject o = cubicle.transform.GetChild(i).gameObject;
                        Face face = o.GetComponent<Face>();
                        face.RotateNormal(new Vector3(0, 0, 90));
                    }
                }
            }
        } else {
            GameObject temp = cubicles[2, 0, 0];
            cubicles[2, 0, 0] = cubicles[2, 0, 2];
            cubicles[2, 0, 2] = cubicles[2, 2, 2];
            cubicles[2, 2, 2] = cubicles[2, 2, 0];
            cubicles[2, 2, 0] = temp;

            // edges
            temp = cubicles[2, 0, 1];
            cubicles[2, 0, 1] = cubicles[2, 1, 2];
            cubicles[2, 1, 2] = cubicles[2, 2, 1];
            cubicles[2, 2, 1] = cubicles[2, 1, 0];
            cubicles[2, 1, 0] = temp;

            /* swap the cubicle gameobjects */

            // rotate the normals
            for (int j = 0; j < 3; j++) {
                for (int k = 0; k < 3; k++) {
                    GameObject cubicle = cubicles[0, j, k];
                    int amount = cubicle.transform.childCount;
                    for (int i = 0; i < amount; ++i) {
                        GameObject o = cubicle.transform.GetChild(i).gameObject;
                        Face face = o.GetComponent<Face>();
                        face.RotateNormal(new Vector3(0, 0, -90));
                    }
                }
            }
        }
    }

    void RotateBlueFace(bool clockwise) {

    }

    void RotateWhiteFace(bool clockwise) {

    }

    void RotateYellowFace(bool clockwise) {

    }

    void Scramble() {

    }

    void GetCenter() {

    }

    void Undo() {

    }

    // start a rotation of a certain side
    void StartRotation(float degrees, Face.Color color) {
        Vector3Int indices = GetSideOfColor(color)[1, 1];
        Vector3 rotation = cubicles[indices.x, indices.y, indices.z].transform.eulerAngles;
        Vector3 normal = Face.GetNormalOfColor(color);
        startingRotation = Vector3.Dot(rotation, normal);
        startTime = Time.time;
        rotatingSide = color;
        degreesToRotate = degrees;
        rotating = true;
    }

    // physically rotate a face
    void InterpolationRotationBro(float degree, Face.Color color) {
        float currentTime = Time.time;
        float timeDifference = currentTime - startTime;
        if (timeDifference >= 1.0f) {
            rotating = false;
            RotateFace(color);
        } else {
            float thisRotation = Mathf.Lerp(startingRotation, startingRotation + degree, timeDifference);
            Vector3 normal = Face.GetNormalOfColor(color);
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    Vector3Int position = GetSideOfColor(color)[i, j];

                    // reset rotation
                    cubicles[position.x, position.y, position.z].transform.RotateAround(new Vector3(0, 0, 0), normal, -lastRotation);

                    // apply new rotation
                    cubicles[position.x, position.y, position.z].transform.RotateAround(new Vector3(0, 0, 0), normal, thisRotation);
                }
            }
            lastRotation = thisRotation;
        }
    }

    void RotateFace(Face.Color color) {
        switch(color) {
            case Face.Color.red:
                RotateRedFace(true);
                break;
            case Face.Color.orange:
                RotateOrangeFace(true);
                break;
            case Face.Color.green:
                RotateGreenFace(true);
                break;
            case Face.Color.blue:
                RotateBlueFace(true);
                break;
            case Face.Color.white:
                RotateWhiteFace(true);
                break;
            case Face.Color.yellow:
                RotateYellowFace(true);
                break;
        }
    }
}
