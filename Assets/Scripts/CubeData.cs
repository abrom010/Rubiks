using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeData {

    // the structure of the cube at the start
    static public readonly string[,,] cubicleNames = new string[3, 3, 3] {  // red front white top
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

    // put the strings into groups for each side
    static public readonly Vector3Int[,] redSide = new Vector3Int[3, 3] {
        { new Vector3Int(0, 0, 0), new Vector3Int(0, 0, 1), new Vector3Int(0, 0, 2) },
        { new Vector3Int(0, 1, 0), new Vector3Int(0, 1, 1), new Vector3Int(0, 1, 2) },
        { new Vector3Int(0, 2, 0), new Vector3Int(0, 2, 1), new Vector3Int(0, 2, 2) }
    };

    static public readonly Vector3Int[,] orangeSide = new Vector3Int[3, 3] {
        { new Vector3Int(2, 0, 0), new Vector3Int(2, 0, 1), new Vector3Int(2, 0, 2) },
        { new Vector3Int(2, 1, 0), new Vector3Int(2, 1, 1), new Vector3Int(2, 1, 2) },
        { new Vector3Int(2, 2, 0), new Vector3Int(2, 2, 1), new Vector3Int(2, 2, 2) }
    };

    static public readonly Vector3Int[,] greenSide = new Vector3Int[3, 3] {
        { new Vector3Int(0, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(0, 2, 0) },
        { new Vector3Int(1, 0, 0), new Vector3Int(1, 1, 0), new Vector3Int(1, 2, 0) },
        { new Vector3Int(2, 0, 0), new Vector3Int(2, 1, 0), new Vector3Int(2, 2, 0) }
    };

    static public readonly Vector3Int[,] blueSide = new Vector3Int[3, 3] {
        { new Vector3Int(0, 0, 2), new Vector3Int(0, 1, 2), new Vector3Int(0, 2, 2) },
        { new Vector3Int(1, 0, 2), new Vector3Int(1, 1, 2), new Vector3Int(1, 2, 2) },
        { new Vector3Int(2, 0, 2), new Vector3Int(2, 1, 2), new Vector3Int(2, 2, 2) }
    };

    static public readonly Vector3Int[,] whiteSide = new Vector3Int[3, 3] {
        { new Vector3Int(0, 0, 0), new Vector3Int(0, 0, 1), new Vector3Int(0, 0, 2) },
        { new Vector3Int(1, 0, 0), new Vector3Int(1, 0, 1), new Vector3Int(1, 0, 2) },
        { new Vector3Int(2, 0, 0), new Vector3Int(2, 0, 1), new Vector3Int(2, 0, 2) }
    };

    static public readonly Vector3Int[,] yellowSide = new Vector3Int[3, 3] {
        { new Vector3Int(0, 2, 0), new Vector3Int(0, 2, 1), new Vector3Int(0, 2, 2) },
        { new Vector3Int(1, 2, 0), new Vector3Int(1, 2, 1), new Vector3Int(1, 2, 2) },
        { new Vector3Int(2, 2, 0), new Vector3Int(2, 2, 1), new Vector3Int(2, 2, 2) }
    };

    /*static public readonly string[,] redSide = new string[3, 3] {
        { "FrontTopLeft", "FrontTopMiddle", "FrontTopRight" },
        { "FrontMiddleLeft", "FrontMiddleMiddle", "FrontMiddleRight" },
        { "FrontBottomLeft", "FrontBottomMiddle", "FrontBottomRight" }
    };

    static public readonly string[,] orangeSide = new string[3, 3] {
        { "BackTopLeft", "BackTopMiddle", "BackTopRight" },
        { "BackMiddleLeft", "BackMiddleMiddle", "BackMiddleRight" },
        { "BackBottomLeft", "BackBottomMiddle", "BackBottomRight" }
    };

    static public readonly string[,] greenSide = new string[3, 3] {
        { "FrontTopLeft", "FrontMiddleLeft", "FrontBottomLeft"},
        { "CenterTopLeft", "CenterMiddleLeft", "CenterBottomLeft" },
        { "BackTopLeft", "BackMiddleLeft", "BackBottomLeft"}
    };

    static public readonly string[,] blueSide = new string[3, 3] {
        { "FrontTopRight", "FrontMiddleRight", "FrontBottomRight"},
        { "CenterTopRight", "CenterMiddleRight", "CenterBottomRight" },
        { "BackTopRight", "BackMiddleRight", "BackBottomRight"}
    };

    static public readonly string[,] whiteSide = new string[3, 3] {
        { "FrontTopLeft", "FrontTopMiddle", "FrontTopRight" },
        { "CenterTopLeft", "CenterTopMiddle", "CenterTopRight" },
        { "BackTopLeft", "BackTopMiddle", "BackTopRight" }
    };

    static public readonly string[,] yellowSide = new string[3, 3] {
        { "FrontBottomLeft", "FrontBottomMiddle", "FrontBottomRight" },
        { "CenterBottomLeft", "CenterBottomMiddle", "CenterBottomRight" },
        { "BackBottomLeft", "BackBottomMiddle", "BackBottomRight" }
    };*/
}
