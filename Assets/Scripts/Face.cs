using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour {
    public enum Color { white, yellow, red, orange, green, blue };

    [SerializeField] Color color;
    Vector3 normal;
    
    public void RotateNormal(Vector3 v) {
        Quaternion rotation = Quaternion.Euler(v.x, v.y, v.z);
        normal = rotation * normal;
    }

    public string GetNormalString() {
        return normal.ToString();
    }

    static public Vector3 GetNormalOfColor(Color color) {
        switch (color) {
            case Color.white:
                return new Vector3(0, 1, 0); // top
            case Color.yellow:
                return new Vector3(0, -1, 0); // down
            case Color.red:
                return new Vector3(0, 0, -1); // front
            case Color.orange:
                return new Vector3(0, 0, 1);  // back
            case Color.green:
                return new Vector3(-1, 0, 0); // left
            case Color.blue:
                return new Vector3(1, 0, 0);  // right
            default:
                return new Vector3(0, 0, 0);
        }
    }

    void Awake() {
        // set the normal of this face according to the color
        normal = GetNormalOfColor(color);
    }
}
