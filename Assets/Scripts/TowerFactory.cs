using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towersParent;

    Queue<Tower> ringBuffer = new Queue<Tower>();
    Queue<Waypoint> waypointBuffer = new Queue<Waypoint>();

    public void AddTower(Waypoint baseWaypoint)
    {
        if (towerLimit > 0)
        {
            var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity, towersParent);
            baseWaypoint.isPlaceable = false;
            towerLimit--;
            waypointBuffer.Enqueue(baseWaypoint);
            //newTower.baseWaypoint = baseWaypoint;
            ringBuffer.Enqueue(newTower);

        } else
        {
            //print("tower limit reached");
            MoveExistingTower(baseWaypoint);
        }
    }

    private void MoveExistingTower(Waypoint baseWaypoint)
    {
        var oldWaypoint = waypointBuffer.Dequeue();
        oldWaypoint.isPlaceable = true;
        var existingTower = ringBuffer.Dequeue();
        existingTower.transform.position = baseWaypoint.transform.position;
        waypointBuffer.Enqueue(baseWaypoint);
        ringBuffer.Enqueue(existingTower);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
