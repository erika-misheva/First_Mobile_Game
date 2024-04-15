using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    // what to spawn
    [SerializeField] private GameObject obstaclePrefab;
    // where to spawn
    [SerializeField] private Transform spawnOrigin;

    [SerializeField] private Transform obstaclesParent;

    // rate of spawning
    [SerializeField] private float spawnInterval;

    [SerializeField] private float spawnOffset;

    // speed of obstacles
    [SerializeField] private float obstacleSpeed;

    [SerializeField] private float leftmostEdge;

    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        timer = spawnInterval;

        SpawnObstacle();

    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawnObstacle())
        {
            Debug.Log("timer ended. please spawn an obstacle.");
            SpawnObstacle();
        }

        MoveObstacles();

        DestroyObstacles();

    }

    private void DestroyObstacles()
    {
        foreach(Transform obstacle in obstaclesParent)
        {
            if(obstacle.position.x <= leftmostEdge)
            {
                Destroy(obstacle.gameObject);
            }
        }
    }

    private void SpawnObstacle()
    {
        Vector2 randPos = spawnOrigin.position + new Vector3(0, UnityEngine.Random.Range(-spawnOffset, spawnOffset), 0);
        Instantiate(obstaclePrefab, randPos, spawnOrigin.rotation, obstaclesParent);
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
        foreach( Transform child in obstaclesParent)
        {
            child.position += Vector3.left * Time.deltaTime * obstacleSpeed;
        }
    }
}