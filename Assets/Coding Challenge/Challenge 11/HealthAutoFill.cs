using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthAutoFill : MonoBehaviour
{
    private float speed = 6.0f;

    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private float health = 10.0f;
    private float damage = 5.0f;

    void Start()
    {
        
    }

    
    void Update()
    {
        PlayerMovement();
        HealthRefill();
        healthText.text = "Health : " + health.ToString("0");
    }

    private void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(horizontal, vertical) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            health -= damage;
        }
    }

    private void HealthRefill()
    {
        if (health < 10)
        {
            health += 1 * Time.deltaTime;
        }

        else if (health == 10)
        {
            health = 10;
        }
    }
}
