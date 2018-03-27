using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] Collider collisionMesh;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] int hitPoints = 10;
    [SerializeField] int hits = 1;
    ScoreBoard scoreBoard;
 

    // Use this for initialization

    void Start()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();

    }

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();

        boxCollider.isTrigger = false;
    }

    public void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }
    
    void ProcessHit()
    {
        
        scoreBoard.ScoreHit(hitPoints);
        hits--;
        hitParticlePrefab.Play();
    }

    private void KillEnemy()
    {
       
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;
        Destroy(vfx.gameObject, destroyDelay);
        Destroy(gameObject);
    }
}
