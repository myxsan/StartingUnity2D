using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] WaveConfigSO currentWave;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping;
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }
    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {            
            foreach(WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for(int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate (currentWave.GetEnemyPrefab(0), 
                                currentWave.GetStartWaypoint().position,
                                Quaternion.identity,
                                transform);
                    yield return new WaitForSeconds(currentWave.getRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);

    }

}
