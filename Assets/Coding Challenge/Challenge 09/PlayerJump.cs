using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    [SerializeField] private int jumpPower;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, new Vector2(1f, 0.15f), groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpPower);
        }
    }
}
