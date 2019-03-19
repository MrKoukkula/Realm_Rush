using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitpoints = 5;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    FriendlyBase friend;
    
    // Start is called before the first frame update
    void Start()
    {
        friend = FindObjectOfType<FriendlyBase>();
    }

    private void OnParticleCollision(GameObject other)
    {
        //print("im hit");
        processHit();
    }

    void processHit()
    {
        hitpoints -= 1;
        hitParticlePrefab.Play();
        //print("current hitpoints " + hitpoints);
        if (hitpoints <= 0)
        {
            Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
            friend.addPoint();
            killEnemy();
        }
    }

    private void killEnemy()
    {
        Destroy(gameObject);
    }
}
