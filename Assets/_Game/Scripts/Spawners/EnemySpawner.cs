using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private LazerSpawner lazerSpawner;

    protected override void OnInitPool(ObjectPool<Enemy> _objectPool = null)
    {
        EnemyPool enemyPool = new EnemyPool(objectPrefabsList, objectPoolSize, objectsHolder);
        base.OnInitPool(enemyPool);
    }

    protected override void Spawn(List<Enemy> _prefabsArray, float[] _rangeSpawnPosition, Transform _prefabsHolder)
    {
        base.Spawn(_prefabsArray, _rangeSpawnPosition, _prefabsHolder);
        objectPrefab.SetSpeed(objectSpeed);
        objectPrefab.SetLazerPool(lazerSpawner.GetLazerPool());
    }
}