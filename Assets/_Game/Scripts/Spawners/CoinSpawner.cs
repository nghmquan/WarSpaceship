using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : Spawner<Coin>
{
    protected override void OnInitPool(ObjectPool<Coin> _objectPool = null)
    {
        CoinPool coinPool = new CoinPool(objectPrefabsList, objectPoolSize, objectsHolder);
        base.OnInitPool(coinPool);
    }

    protected override void Spawn(List<Coin> _prefabsArray, float[] _rangeSpawnPosition, Transform _prefabsHolder)
    {
        base.Spawn(_prefabsArray, _rangeSpawnPosition, _prefabsHolder);
        objectPrefab.SetSpeed(objectSpeed);
    }
}
