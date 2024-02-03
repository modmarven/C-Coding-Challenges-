using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelLoad : MonoBehaviour
{
    private float speed = 5f;

    public TextMeshProUGUI timerText;
    public GameObject loadPanel;

    private float startTime = 5f;
    private float currentTime = 0f;

    private bool countDownActive;

    void Start()
    {
        loadPanel.SetActive(false);
        currentTime = startTime;
        countDownActive = false;
    }

    
    void Update()
    {
        MovementPlayer();
        CountDownTime();

    }

    private void MovementPlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(horizontal, vertical) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            countDownActive = true;
            loadPanel.SetActive(true);
        }
    }

    private void CountDownTime()
    {
        if (countDownActive)
        {
            currentTime -= 1 * Time.deltaTime;
            timerText.text = currentTime.ToString("0");
        }

        if (currentTime <= 0)
        {
            SceneManager.LoadScene("Level 02");
        }
    }
}
