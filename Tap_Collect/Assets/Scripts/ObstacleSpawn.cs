using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField] private float spawnY = 8f;
    [SerializeField] private float minX = -2.2f;
    [SerializeField] private float maxX = 2.2f;
    [SerializeField] private float delayTime = 1f;


    public List<GameObject> obstacles;

    public  void RunGame()
    {

        delayTime = DifficultManager.instance.currentDifficulty.spawnDelay;
        StartCoroutine(ReadyForSpawn());
    }
    public void StopCoroutine()
    {
        StopAllCoroutines();
    }
    void Spawn()
    {
        if (GameManager.instance.isGameOver)
            return;
        int randomIndex = Random.Range(0, obstacles.Count);
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);
        Instantiate(obstacles[randomIndex], spawnPosition, Quaternion.identity);
    }

    IEnumerator ReadyForSpawn()
    {
        while (true)
        {
            if (!GameManager.instance.isGameOver)
                Spawn();

            yield return new WaitForSeconds(delayTime);
        }


    }
   
}
