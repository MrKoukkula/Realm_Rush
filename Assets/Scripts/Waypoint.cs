using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    Vector2Int gridPos;
    const int gridSize = 10;
    public bool isExplored = false;
    public Waypoint exploredFrom;

    public float GetGridSize
    {
        get { return gridSize; }
    }

    public Vector2Int GetGridPos
    {
        get
        {
            return new Vector2Int(
                Mathf.RoundToInt(transform.position.x / gridSize),
                Mathf.RoundToInt(transform.position.z / gridSize)
            );
        }
    }

    public void SetTopColor(Color color)
    {
        //print(transform.Find("top").GetComponent<MeshRenderer>());
        MeshRenderer top = transform.Find("top").GetComponent<MeshRenderer>();
        top.material.color = color;
    }
}
