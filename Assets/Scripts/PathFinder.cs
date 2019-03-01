using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter;

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
        LoadBlocks(); //Load the world
        addStartAndEnd(); //Mark the start and end points
        PathFind(); //Start searching
    }

    private void PathFind()
    {
        queue.Enqueue(startWaypoint); //Because the queue is empty, addthe start point

        while (queue.Count > 0 && isRunning) // As long as the queue is not empty, this loop will run.
        {
            searchCenter = queue.Dequeue(); // pop the first item from the queue
            print("Searching from " + searchCenter);
            HaltIfEndFound(); //Check if the item is the endpoint
            // explore neightbours
            ExploreNeightbours(); //If the item is not the endpoint, look and add neighbours to queue
            searchCenter.isExplored = true;
        }
        // todo work-out the best path
    }

    private void ExploreNeightbours() //Check for nodes in neighbouring squares
    {
        if (!isRunning) { return; };

        foreach(Vector2Int direction in directions) // Check the 4 directions of the current searchpoint
        {
            Vector2Int explorationPos = searchCenter.GetGridPos + direction; //Search direction is up, right, down, left
            //print("Exploring " + explorationPos);
            try
            {
                queueNewNeighbour(explorationPos);
            }
            catch
            {
                // Do nothing
            }
        }
    }

    private void queueNewNeighbour(Vector2Int explorationPos)
    {
        Waypoint neighbour = grid[explorationPos]; //Find the item from the dictionary and place it into the queue
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
            
        } else
        {
            //neighbour.SetTopColor(Color.blue);
            neighbour.exploredFrom = searchCenter;
            queue.Enqueue(neighbour);
            print("queuing from " + neighbour);
        }
        
    }

    private void HaltIfEndFound() // This only checks if the current waypoint if the end
    {
        if (searchCenter == endWaypoint)
        {
            print("Endpoint found");
            isRunning = false;
            return;
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
