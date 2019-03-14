using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyMovement enemy;
    [SerializeField] Transform enemyParent;
    [SerializeField] float secondsBetweenSpawns;
    [SerializeField] int amountOfEnemies;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }


    IEnumerator spawnEnemy()
    {
        while (amountOfEnemies != 0)
        {
            Instantiate(enemy, transform);
            yield return new WaitForSeconds(secondsBetweenSpawns);
            amountOfEnemies--;
        }
        
    }
}
