using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerup : MonoBehaviour
{
    public GameObject PlayerObj;
    public GameObject pickupEffect;
    public float multiplier = 1.25f;
    
    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        PlayerHealth stats = player.GetComponent<PlayerHealth>();
        stats.maxHealth *= multiplier;
        stats.currentHealth = stats.maxHealth;
        Destroy(gameObject);
    }
}
