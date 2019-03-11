using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] ParticleSystem bullets;
    [SerializeField] float attackRange = 10f;

    // Update is called once per frame
    void Update()
    {
        if (targetEnemy)
        {
        objectToPan.LookAt(targetEnemy);
        fireAtEnemy();
        } else
        {
            Shoot(false);
        }
        
    }

    private void fireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        print(distanceToEnemy);
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
