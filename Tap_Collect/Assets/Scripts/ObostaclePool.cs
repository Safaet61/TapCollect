using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObostaclePool : MonoBehaviour
{
    public static ObostaclePool instance;
    [SerializeField] private List<GameObject> obstaclePrefabs;
    [SerializeField] private int poolSize = 20;

    private Queue<GameObject> pool = new Queue<GameObject>();
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            int randomIndex = Random.Range(0, obstaclePrefabs.Count);

            GameObject obj = Instantiate(obstaclePrefabs[randomIndex], transform);

            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject GetObstacle()
    {
        if (pool.Count == 0)
            return null;

        GameObject obj = pool.Dequeue();
        obj.SetActive(true);

        return obj;
    }



    public void ReturnObstacle(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}