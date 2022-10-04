using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 50;
    public int currentHealth;
    public int Respawn;
    public HealthBar healthBar;

    void Start()
    {
        maxHealth = 50;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            TakeDamage(12);

       if(currentHealth <=0)
            {
               SceneManager.LoadScene(Respawn);
            }
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

    }
}
