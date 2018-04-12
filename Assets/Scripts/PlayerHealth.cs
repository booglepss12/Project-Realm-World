using System.Collections;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PlayerHealth : MonoBehaviour
{
    PlayerDamage player;


    [SerializeField] int health = 20;

    [SerializeField] Text healthText;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] AudioClip enemyToBase;
     void Start()
    {
        player = FindObjectOfType<PlayerDamage>();
        Invoke("LoadNextScene", 4f);
    }


    private void OnTriggerEnter(Collider other)

    {
        
        ProcessHit();
        if (health < 0)
        {
            KillPlayer();
        }
    }

    private void ProcessHit()
    {
        GetComponent<AudioSource>().PlayOneShot(enemyToBase);
        health -= healthDecrease;
        healthText.text = health.ToString();
       
    }


    private void KillPlayer()
    {
        
        Destroy(gameObject);
        SceneManager.LoadScene(2);
    }

}




