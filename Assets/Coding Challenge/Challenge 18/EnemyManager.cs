using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float startHealth = 30f;
    private float currentHealth;
    private float bulletDamage = 10f;

    private void Start()
    {
        currentHealth = startHealth;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            currentHealth -= bulletDamage;
            Debug.Log(currentHealth);

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
