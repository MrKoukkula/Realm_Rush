using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    List<Waypoint> path;
    // Start is called before the first frame update
    PathFinder pathFinder;
    [SerializeField] float enemyMovement = 0.5f;
    [SerializeField] ParticleSystem explosionParticles;

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
            yield return new WaitForSeconds(enemyMovement);
        }
        print("Ending patrol");
        Instantiate(explosionParticles, transform.position, Quaternion.identity);
        Invoke("killEnemy", 0.1f);
    }

    private void killEnemy()
    {
        Destroy(gameObject);
    }

}
