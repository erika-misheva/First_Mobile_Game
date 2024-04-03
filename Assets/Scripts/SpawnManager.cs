using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // what to spawn
    [SerializeField] private GameObject obstaclePrefab;
    // where to spawn
    [SerializeField] private Transform spawnOrigin;

    // rate of spawning
    [SerializeField] private float spawnInterval;

    // speed of obstacles
    [SerializeField] private float obstacleSpeed;

    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        timer = spawnInterval;

    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawnObstacle())
        {
            Debug.Log("timer ended. please spawn an obstacle.");
            // SpawnObstacle();
        }

        MoveObstacles();

    }

    private bool ShouldSpawnObstacle()
    {

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = spawnInterval;
            return true;
        }

        return false;
    }

    private void MoveObstacles()
    {
        // movement code
    }
}