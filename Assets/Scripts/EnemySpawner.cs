using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyMovement enemy;
    [SerializeField] Transform enemyParent;
    [SerializeField] float secondsBetweenSpawns;
    [SerializeField] int amountOfEnemies;
    [SerializeField] Text enemyAmount;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy());
        enemyAmount.text = "Enemies: " + score;

    }
    

    IEnumerator spawnEnemy()
    {
        while (amountOfEnemies != 0)
        {

            Instantiate(enemy, transform);
            score++;
            enemyAmount.text = "Enemies: " + score;
            yield return new WaitForSeconds(secondsBetweenSpawns);
            amountOfEnemies--;
            
        }
        
    }
}
