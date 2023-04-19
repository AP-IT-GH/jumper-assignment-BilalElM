using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject coin;
    public int maxObstacles = 3;  // maximum number of obstacles in the scene
    public int maxCoins = 3;      // maximum number of coins in the scene
    public float spawnTime = 25f;
    private float counter = 0f;

    private void Spawn()
    {
        // Count the number of obstacles and coins in the scene
        int numObstacles = GameObject.FindGameObjectsWithTag("Obstacle").Length;
        int numCoins = GameObject.FindGameObjectsWithTag("Coin").Length;

        // Spawn a new obstacle or coin if there's room for it
        if (numObstacles < maxObstacles && numCoins < maxCoins)
        {
            int random = Random.Range(0, 6);
            if (random > 2)
            {
                GameObject a = Instantiate(obstacle);
                a.tag = "Obstacle";
                a.transform.localPosition = new Vector3(4f, 0.5f, -3.85f);
            }
            else
            {
                GameObject b = Instantiate(coin);
                b.tag = "Coin";
                b.transform.localPosition = new Vector3(6f, 1.5f, -3.85f);
            }
        }
    }

    void Update()
    {
        if (counter <= 0)
        {
            counter = spawnTime;
            Spawn();
        }
        counter -= Time.deltaTime;
    }
}
