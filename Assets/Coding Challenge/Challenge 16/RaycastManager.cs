using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    public Transform rayStart;
    public Transform rayEnd;
    public LayerMask layerMask;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        
    }

    
    void Update()
    {
        PlayerDetector();
        
    }

    private void PlayerDetector()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayStart.position, (rayEnd.position - rayStart.position).normalized, Vector2.Distance(rayStart.position, rayEnd.position), layerMask);

        Debug.DrawLine(rayStart.position, rayEnd.position, Color.green);

        if (hit.collider != null && hit.collider.gameObject.tag == "Player")
        {
            spriteRenderer.material.color = Color.red;
        }

    }
}
