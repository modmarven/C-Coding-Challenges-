using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private Rigidbody2D rigidBody2d;
    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        rigidBody2d.isKinematic = true;
    }

    private void OnMouseDown()
    {
        rigidBody2d.isKinematic = false;
    }
}
