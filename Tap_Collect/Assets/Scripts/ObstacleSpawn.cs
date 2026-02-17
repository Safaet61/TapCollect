using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField] private ObostaclePool obostaclePool;
    [SerializeField] private float spawnY = 8f;
    [SerializeField] private float minX = -2.2f;
    [SerializeField] private float maxX = 2.2f;
    [SerializeField] private float delayTime = 1f;

 
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
        GameObject obstacle = obostaclePool.GetObstacle();

        float randomX = Random.Range(minX, maxX);
        obstacle.transform.position = new Vector3(randomX, spawnY, 0);
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
