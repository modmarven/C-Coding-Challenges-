using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerSystem : MonoBehaviour
{
    public float speed = 5.0f;
    public float increseSpeed = 10.0f;
    public float powerDuration = 3.0f;
    public float powerTime = 0f;
    public bool isPower = false;
    public TextMeshProUGUI activePowerText;
    public TextMeshProUGUI speedText;

    void Start()
    {
        powerTime = powerDuration;
    }


    void Update()
    {
        PlayerMovement();
        PowerUp();
        speedText.text = "Speed : " + speed.ToString("0");
    }
    
    private void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical) * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void PowerUp()
    {
        if (isPower)
        {
            powerTime -= 1 * Time.deltaTime;
            activePowerText.text = "Power Active Time : " + powerTime.ToString("0");

            if (powerTime <= 0)
            {
                DeactivatePower();
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Power")
        {
            Destroy(collision.gameObject);
            ActivatePower();
        }
    }

    private void ActivatePower()
    {
        isPower = true;
        speed += increseSpeed;
    }

    private void DeactivatePower()
    {
        isPower = false;
        speed -= increseSpeed;
    }
}
