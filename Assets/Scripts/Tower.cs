﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Parameters of each tower
    [SerializeField] Transform objectToPan;
    [SerializeField] ParticleSystem bullets;
    [SerializeField] float attackRange = 10f;

    // State of each tower
    Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
        setTargetEnemy();

        if (targetEnemy)
        {
        objectToPan.LookAt(targetEnemy);
        fireAtEnemy();
        } else
        {
            Shoot(false);
        }
        
    }

    private void setTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0)
        {
            return;
        }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transform.position, transformA.position);
        var distToB = Vector3.Distance(transform.position, transformB.position);

        if (distToA < distToB)
        {
            return transformA;
        } else
        {
            return transformB;
        }
    }

    private void fireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        //print(distanceToEnemy);
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        } else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool v)
    {
        var emissionModule = bullets.emission;
        emissionModule.enabled = v;
    }
}
