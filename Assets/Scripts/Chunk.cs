using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] float[] lanes = { -2.5f, 0f, 2.5f };

    [SerializeField] float appleSpawnChance = .3f;
    [SerializeField] float coinSpawnChance = .5f;
    [SerializeField] float coinSeparationLength = 2f;

    LevelGenerator levelGenerator;
    ScoreManagers scoreManagers;
    List<int> availableLanes = new List<int> { 0, 1, 2 };


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnFence();
        SpawnApple();
        SpawnCoin();
    }


    public void Init(LevelGenerator levelGenerator,ScoreManagers scoreManagers)
    {
        this.levelGenerator = levelGenerator;
        this.scoreManagers = scoreManagers;
    }


    public void SpawnFence()
    {

        int fencesToSpawn = Random.Range(0, lanes.Length);
        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLanes.Count <= 0) break;
            int selectedLane = SelectLane();
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            GameObject fence = Instantiate(fencePrefab, spawnPosition, Quaternion.identity);
            fence.transform.SetParent(transform, worldPositionStays: true);

        }
    }

    private void SpawnApple()
    {
        if (Random.value > appleSpawnChance || availableLanes.Count <= 0) return;
        if (availableLanes.Count <= 0) return;
        int selectedLane = SelectLane();
        Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y + 0.4f, transform.position.z);
        GameObject apple = Instantiate(applePrefab, spawnPosition, Quaternion.identity);
        apple.transform.SetParent(transform, worldPositionStays: true);
        apple.GetComponent<Apple>().Init(levelGenerator);
    }
    
     private void SpawnCoin()
    {
        if (Random.value > coinSpawnChance || availableLanes.Count<=0) return;
        if (availableLanes.Count <= 0) return;
        int selectedLane = SelectLane();
        // int maxCoinToSpawn = 6;
        int coinsToSpawn = Random.Range(1, 6);
        float topOfChunkZpos = transform.position.z + (coinSeparationLength * 2f);
        for (int i = 0; i < coinsToSpawn; i++)
        {
            float spawnPositionZ = topOfChunkZpos - (i * coinSeparationLength);
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y + 0.4f, spawnPositionZ);
            GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
            coin.transform.SetParent(transform, worldPositionStays: true);
            coin.GetComponent<Coin>().Init(scoreManagers);
            
        }
    }


    private int SelectLane()
    {

        int randomLaneIndex = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }

    }
    



  

