using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField] private float spawnY = 8f;
    [SerializeField] private float minX = -2.2f;
    [SerializeField] private float maxX = 2.2f;

    public List<GameObject> obstacles ;
    void Start()
    {
        InvokeRepeating(nameof(spawn), 1f, 1f);
    }

    void spawn()
    {
        int randomIndex = Random.Range(0, obstacles.Count);
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);
        Instantiate(obstacles[randomIndex], spawnPosition,Quaternion.identity);
    }
}
