using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;

    public Color color = Color.red;
    public GameObject changeColor;

    public Renderer render;

    void Start()
    {
        
    }

    
    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trigger")
        {
            ColourChange();
        }
    }

    private void ColourChange()
    {
        render = changeColor.GetComponent<Renderer>();
        render.material.color = color;
    }
}
