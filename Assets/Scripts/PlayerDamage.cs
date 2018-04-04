using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour {

    int score = 20;
    Text scoretext;

    // Use this for initialization
    void Start()
    {
        scoretext = GetComponent<Text>();
        scoretext.text = score.ToString();
    }

    public void PlayerHealth(int scorePerHit)
    {
        score = score - scorePerHit; 
        scoretext.text = score.ToString();
    }
}
