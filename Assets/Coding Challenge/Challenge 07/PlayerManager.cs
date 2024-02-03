using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private TextMeshProUGUI coinCount;
    private int score;
    private AudioSource collectSound;
    public AudioClip collectSFX;

    void Start()
    {
        collectSound = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        MovementPlayer();
        coinCount.text = "Score : " + score;
    }

    private void MovementPlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector2.right * horizontal * speed * Time.deltaTime);
        transform.Translate(Vector2.up * vertical * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            score++;
            Debug.Log("Collected");
            collision.gameObject.SetActive(false);
            collectSound.PlayOneShot(collectSFX);
        }
    }
}
