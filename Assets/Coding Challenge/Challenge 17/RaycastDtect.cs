using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDtect : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public LayerMask layerMask;
    public bool inRay;
    public SpriteRenderer houseColour;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        PlayerDetect();
    }

    private void PlayerDetect()
    {
        RaycastHit2D hit2D = Physics2D.Linecast(startPoint.position, endPoint.position, layerMask);
        Debug.DrawLine(startPoint.position, endPoint.position, Color.green);

        if (hit2D.collider != null && hit2D.collider.gameObject.tag == "Player")
        {
            if (!inRay)
            {
                Debug.Log("Player Entered");
                inRay = true;
            }
        }

        else
        {
            if (inRay)
            {
                houseColour.material.color = Color.green;
                Debug.Log("Player Exit");
                inRay = false;
                
            }
        }
    }
}
