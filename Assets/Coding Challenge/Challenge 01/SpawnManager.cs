using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefabs;

    private float spawnValueX = 9.0f;
    private float spawnValueY = 4.5f;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float spawnPositionX = Random.Range(-spawnValueX, spawnValueX);
            float spawnPositionY = Random.Range(-spawnValueY, spawnValueY);

            playerPrefabs = Instantiate(playerPrefabs, new Vector2(spawnPositionX, spawnPositionY), Quaternion.identity);
        }
    }
}
