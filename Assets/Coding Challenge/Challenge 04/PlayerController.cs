using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0f;
    private float health = 10.0f;

    void Start()
    {
        
    }

    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(horizontal, vertical) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
            Debug.Log(health);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Player Destroy");
        }
    }
}
