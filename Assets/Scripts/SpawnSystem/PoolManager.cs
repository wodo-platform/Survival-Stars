using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject healthPrefab;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject goldPrefab;
    
    private ObjectPool<GameObject> _enemyPool;
    private ObjectPool<GameObject> _healthPool;
    private ObjectPool<GameObject> _bulletPool;
    private ObjectPool<GameObject> _goldPool;

    private void Awake()
    {
        Instance = this;

        _enemyPool = CreatePool(enemyPrefab);
        _healthPool = CreatePool(healthPrefab);
        _bulletPool = CreatePool(bulletPrefab);
        _goldPool = CreatePool(goldPrefab);
    }

    private ObjectPool<GameObject> CreatePool(GameObject prefab)
    {
        return new ObjectPool<GameObject>(
            createFunc: () => Instantiate(prefab),
            actionOnGet: obj => obj.SetActive(true),
            actionOnRelease: obj => obj.SetActive(false),
            actionOnDestroy: obj => Destroy(obj),
            collectionCheck: false,
            defaultCapacity: 10,
            maxSize: 50);
    }

    public GameObject GetFromPool(ObjectType objectType)
    {
        return objectType switch
            {
                ObjectType.Enemy => _enemyPool.Get(),
                ObjectType.Health => _healthPool.Get(),
                ObjectType.Bullet => _bulletPool.Get(),
                ObjectType.Gold => _goldPool.Get(),
                _ => null,
            }
            ;
    }

    public void ReturnToPool(ObjectType type, GameObject obj)
    {
        switch (type)
        {
            case ObjectType.Enemy:
                _enemyPool.Release(obj);
                break;
            case ObjectType.Health:
                _healthPool.Release(obj);
                break;
            case ObjectType.Bullet:
                _bulletPool.Release(obj);
                break;
            case ObjectType.Gold:
                _goldPool.Release(obj);
                break;
            default:
                Debug.LogError($"{nameof(ObjectType)} is not supported");
                break;
        }
    }
}

public enum ObjectType
{
    Enemy,
    Health,
    Bullet,
    Gold
}

