using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        addStartAndEnd();
        ExploreNeightbours();
    }

    private void ExploreNeightbours()
    {
        foreach(Vector2Int direction in directions)
        {
            Vector2Int explorationPos = startWaypoint.GetGridPos + direction;
            print("Exploring " + explorationPos);
            grid[explorationPos].SetTopColor(Color.blue);
        }
        
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();

        foreach (Waypoint point in waypoints)
        {
            if (grid.ContainsKey(point.GetGridPos))
            {
                Debug.LogWarning("Skipping overlapping block " + point);
            }
            else
            {
                grid.Add(point.GetGridPos, point);
            }
        }
        print("Loaded "+grid.Count+" blocks.");
    }

    private void addStartAndEnd()
    {
            startWaypoint.SetTopColor(Color.grey);
            endWaypoint.SetTopColor(Color.black);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
