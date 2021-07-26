using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour {
    enum Color { white, yellow, red, orange, green, blue };

    [SerializeField] Color color;
    Vector3 normal;
    
    public void RotateNormal(Vector3 v) {
        // inverting
        v.x = -v.x;
        v.y = -v.y;
        v.z = -v.z;

        Quaternion rotation = Quaternion.Euler(v.x, v.y, v.z);
        normal = rotation * normal;
    }

    public string GetNormalString() {
        return normal.ToString();
    }

    void Awake() {
        // set the normal of this face according to the color
        switch(color) {
            case Color.white:
                normal = new Vector3(0, 1, 0); // top
                break;
            case Color.yellow:
                normal = new Vector3(0, -1, 0); // down
                break;
            case Color.red:
                normal = new Vector3(0, 0, -1); // front
                break;
            case Color.orange:
                normal = new Vector3(0, 0, 1);  // back
                break;
            case Color.green:
                normal = new Vector3(-1, 0, 0); // left
                break;
            case Color.blue:
                normal = new Vector3(1, 0, 0);  // right
                break;
        }
    }
}
