using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    List<Waypoint> path;
    // Start is called before the first frame update
    PathFinder pathFinder;


    void Start()
    {
        pathFinder = FindObjectOfType<PathFinder>();
        path = pathFinder.getPath;
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> pathRoute)
    {
        //print("Starting patrol");
        foreach (Waypoint waypoint in pathRoute)
        {
            transform.position = waypoint.transform.position;
            //print("Patrolling at " + waypoint.name);
            yield return new WaitForSeconds(1f);
        }
        //print("Ending patrol");
    }

}
