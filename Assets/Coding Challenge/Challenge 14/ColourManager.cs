using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class ColourManager : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;

    private float startTime = 5f;
    private float currentTime = 0f;
    private float playerTwoTime = 0;

    public List <TextMeshProUGUI> timeCount;
    public List<SpriteRenderer> spriteRenderers;

    void Start()
    { 
        currentTime = startTime;
        playerTwoTime = startTime;
    }

    
    void Update()
    {
        PlayerOne();
    }

    private void PlayerOne()
    {
       currentTime -= 1 * Time.deltaTime;
       timeCount.ElementAt(0).text = "Timer : " + currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            spriteRenderers.ElementAt(0).material.color = Color.red;
            PlayerTwo();
        }
    }

    private void PlayerTwo()
    {
        playerTwoTime -= 1 * Time.deltaTime;
        timeCount.ElementAt(1).text = "Timer : " + playerTwoTime.ToString("0");

        if (playerTwoTime <= 0)
        {
            playerTwoTime = 0;
            spriteRenderers.ElementAt(1).material.color = Color.green;
        }
    }
}
