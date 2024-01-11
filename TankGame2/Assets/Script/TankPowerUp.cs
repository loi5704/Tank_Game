using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPowerUp : MonoBehaviour
{
    public PowerUpEffect powerupEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HaveOnTrigger");
        Destroy(gameObject);
        powerupEffect.Apply(collision.gameObject);
    }
}
