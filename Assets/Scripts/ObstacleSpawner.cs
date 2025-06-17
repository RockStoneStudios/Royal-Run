using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] int poolSize = 5;
    [SerializeField] float timeOfCreateObstacle = 4.2f;
    [SerializeField] GameObject[] prefabs;
    [SerializeField] float spanwWidth = 4f;
    private PlayerController playerController;
    private Queue<GameObject> pool = new Queue<GameObject>();



    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        AddToPool(poolSize);
        StartCoroutine(TimeOfSpawnObstacle());
    }

    void AddToPool(int poolSize)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obstacle = Instantiate(prefabs[Random.Range(0,prefabs.Length)], transform.position, Quaternion.identity);
            obstacle.transform.SetParent(transform);
            obstacle.SetActive(false);
            pool.Enqueue(obstacle);

        }
    }


    public void DesactivateObstacle(GameObject gameObject)
    {
        gameObject.SetActive(false);
        pool.Enqueue(gameObject);
    }

    void SpawnObstacle()
    {
        if (pool.Count > 0)
        {
            GameObject obstacle = pool.Dequeue();
            obstacle.transform.position = new Vector3(Random.Range(-spanwWidth,spanwWidth),transform.position.y,transform.position.z);
            obstacle.transform.rotation = transform.rotation;
            obstacle.SetActive(true);
        }
        else
        {
            AddToPool(1);
        }
    }


    private IEnumerator TimeOfSpawnObstacle()
    {
        while (true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(Random.Range(0.8f, timeOfCreateObstacle));
        }
    }

}
