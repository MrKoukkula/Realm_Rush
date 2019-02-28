using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        addStartAndEnd();
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
