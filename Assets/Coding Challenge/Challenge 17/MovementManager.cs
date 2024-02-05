using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    [SerializeField] private float moveSpeed = 5.0f;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rigidBody2D.velocity = new Vector3(horizontal, vertical, 0) * moveSpeed * Time.fixedDeltaTime;
        rigidBody2D.velocity.Normalize();
    }
}
