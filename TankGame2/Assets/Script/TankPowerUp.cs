using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPowerUp : MonoBehaviour
{
    public PowerUpEffect powerupEffect;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ScoreScript scoreScript = FindObjectOfType<ScoreScript>();
        //if (scoreScript != null)
        //{
        //    scoreScript.LoadScore();
        //    int loadedScore = ScoreScript.ScoreScene;
        //    Debug.Log("Loaded Score: " + loadedScore);
        //}
        //else
        //{
        //    Debug.LogError("ScoreScript not found!");
        //}
        Debug.Log("HaveOnTrigger");
        Destroy(gameObject);
        powerupEffect.Apply(collision.gameObject);
    }
}

