using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitpoints = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        print("im hit");
        processHit();
    }

    void processHit()
    {
        hitpoints -= 1;
        print("current hitpoints " + hitpoints);
        if (hitpoints <= 0)
        {
            killEnemy();
        }
    }

    private void killEnemy()
    {
        Destroy(gameObject);
    }
}
