﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] AudioClip enemySpawnedFX;
	// Use this for initialization
	void Start ()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
	}
	
    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) // forever
        {
            GetComponent<AudioSource>().PlayOneShot(enemySpawnedFX);
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
