using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    private float countDownTime = 0;
    private float startTime = 5;
    public GameObject gameOver;
    public TextMeshProUGUI textMeshPro;

    void Start()
    {
        countDownTime = startTime;
        gameOver.SetActive(false);
    }

    
    void Update()
    {
        countDownTime -= 1 * Time.deltaTime;
        textMeshPro.text = countDownTime.ToString("0");

        if (countDownTime == 0)
        {
            countDownTime = 0;
            gameOver.SetActive(false);
        }

        if (countDownTime < 0)
        {
            gameOver.SetActive(true);
        }
    }
}
