using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public class SpawnConfig
    {
        public ObjectType objectType;
        public float spawnInterval;
    }

    [SerializeField] private Vector2 spawnAreaMinimum;
    [SerializeField] private Vector2 spawnAreaMaximum;
    
    [SerializeField] private SpawnConfig[] spawnConfigs;
    [SerializeField] private PlayerHealth playerHealth;

    private void Start()
    {
        foreach (var config in spawnConfigs)
        {
            StartCoroutine(SpawnRoutine(config));
        }
    }

    IEnumerator SpawnRoutine(SpawnConfig config)
    {
        WaitForSeconds wait = new WaitForSeconds(config.spawnInterval);

        while (!playerHealth.IsDead)
        {
            Spawn(config.objectType);
            yield return wait;
        }
    }

    private void Spawn(ObjectType type)
    {
        Vector2 position = new Vector2(
            Random.Range(spawnAreaMinimum.x, spawnAreaMaximum.x),
            Random.Range(spawnAreaMinimum.y, spawnAreaMaximum.y));

        GameObject obj = PoolManager.Instance.GetFromPool(type);
        obj.transform.position = position;
    }
}
