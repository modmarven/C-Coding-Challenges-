using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDetect : MonoBehaviour
{
    public Transform startRay;
    public Transform endRay;
    public LayerMask layerMask;
    public bool rayIn;
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
        RaycastHit2D hit2D = Physics2D.Linecast(startRay.position, endRay.position, layerMask);
        Debug.DrawLine(startRay.position, endRay.position, Color.red);

        if (hit2D.collider != null && hit2D.collider.gameObject.tag == "Player")
        {
            if (!rayIn)
            {
                Debug.Log("Player Entered");
                rayIn = true;
            }
        }

        else
        {
            if (rayIn)
            {
                houseColour.material.color = Color.green;
                Debug.Log("Player Exit");
                rayIn = false;
            }
        }
    }

}
