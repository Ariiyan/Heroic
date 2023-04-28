using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveLogic : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public List<GameObject> enemyPrefabs;
        public List<float> spawnRates;
    }

    public List<Wave> waves;
    public SpawnPoint[] spawnPoints;
    public int enemiesPerWave = 5;
    public int waveNumber = 1;
    public float timeBetweenWaves = 10f;

    private int enemiesRemaining;

    void Start()
    {
        enemiesRemaining = enemiesPerWave;
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            for (int i = 0; i < enemiesPerWave; i++)
            {
                SpawnPoint spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                Wave currentWave = waves[Mathf.Min(waveNumber - 1, waves.Count - 1)];
                GameObject enemyPrefab = GetRandomEnemy(currentWave);

                spawnPoint.SpawnEnemy(enemyPrefab);
                enemiesRemaining--;
                yield return new WaitForSeconds(1f);
            }

            if (enemiesRemaining <= 0)
            {
                waveNumber++;
                enemiesPerWave += waveNumber;
                enemiesRemaining = enemiesPerWave;
                yield return new WaitForSeconds(timeBetweenWaves);
            }
            yield return null;
        }
    }

    GameObject GetRandomEnemy(Wave wave)
    {
        float total = 0;
        foreach (float spawnRate in wave.spawnRates)
        {
            total += spawnRate;
        }

        float randomPoint = Random.value * total;
        for (int i = 0; i < wave.spawnRates.Count; i++)
        {
            if (randomPoint < wave.spawnRates[i])
            {
                return wave.enemyPrefabs[i];
            }
            else
            {
                randomPoint -= wave.spawnRates[i];
            }
        }

        return wave.enemyPrefabs[wave.enemyPrefabs.Count - 1];
    }
}