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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy());
        //updateEnemyAmount();
    }

    //private void updateEnemyAmount()
    //{
    //    var enemies = FindObjectsOfType<EnemyMovement>();
    //    enemyAmount.text = "Enemy amount: " + enemies.Length;
    //}

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
