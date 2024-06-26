using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class SpawnObstacleManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public int obstacleIndex;
    public float pathOffset;
    private float spawnDelay = 2f;
    public float spawnInterval = 1.5f;

    void Start()
    {
        obstacleIndex = Random.Range(0, obstacles.Length);
        pathOffset = Singleton.Instance.pathOffset;
        InvokeRepeating("SpawnRandomObstacle", spawnDelay, spawnInterval);


    }

    void SpawnRandomObstacle()
    {
        if (obstacleIndex >= 0 && obstacleIndex < obstacles.Length)
        {
            float[] possibleOffsets = { -pathOffset, 0, pathOffset };
            float randomOffset = possibleOffsets[Random.Range(0, possibleOffsets.Length)];

            Vector3 spawnPosition = new Vector3(randomOffset, 0, 0);
            GameObject newObstacle = Instantiate(obstacles[obstacleIndex], transform.position, transform.rotation, transform);
            newObstacle.tag = "Obstacle";
            newObstacle.transform.localRotation = Quaternion.Euler(0, 270, 0);
            newObstacle.transform.localPosition = spawnPosition;

            obstacleIndex = Random.Range(0, obstacles.Length);
        }
        else
        {
            Debug.LogError("Obstacle index out of range");
        }
    }

}
