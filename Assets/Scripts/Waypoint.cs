﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    Vector2Int gridPos;
    const int gridSize = 10;
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;

    [SerializeField] Tower tower;

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

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isPlaceable)
        {
            Instantiate(tower, transform.position, Quaternion.identity);
            isPlaceable = false;
        }

    }

}
