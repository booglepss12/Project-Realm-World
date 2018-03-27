using System.Collections;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;




public class PlayerHealth : MonoBehaviour
{
    PlayerDamage player;


    [SerializeField] int health = 20;

    [SerializeField] int healthDecrease = 1;
     void Start()
    {
        player = FindObjectOfType<PlayerDamage>();
        Invoke("LoadNextScene", 4f);
    }


    private void OnTriggerEnter(Collider other)

    {
        ProcessHit();
        if(health < 0)
        {
            KillPlayer();
        }
    }

    private void ProcessHit()
    {
        health = health - healthDecrease;
        player.PlayerHealth(healthDecrease);
    }

    private void KillPlayer()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(1);
    }

}




