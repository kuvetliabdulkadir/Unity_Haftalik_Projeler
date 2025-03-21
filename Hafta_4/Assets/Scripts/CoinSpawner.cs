using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 2f;
    public float minX = -5f, maxX = 5f;
    public float spawnZ = 10f;

    void Start()
    {
        InvokeRepeating("SpawnCoin", 1f, spawnInterval);
    }

    void SpawnCoin()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, 0.5f, spawnZ);
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}