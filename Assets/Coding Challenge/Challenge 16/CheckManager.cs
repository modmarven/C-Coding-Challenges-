using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckManager : MonoBehaviour
{
    private float moveSpeed = 5.0f;

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

}
