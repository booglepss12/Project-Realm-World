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
    [SerializeField] AudioClip enemyDamageSFX;
    [SerializeField] AudioClip enemyDeathSFX;
    ScoreBoard scoreBoard;
    AudioSource audioSource;

    // Use this for initialization

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        audioSource.PlayOneShot(enemyDamageSFX);
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
        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
