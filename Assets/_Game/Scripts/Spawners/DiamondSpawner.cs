using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondSpawner : Spawner<Diamond>
{
    protected override void OnInitPool(ObjectPool<Diamond> _objectPool = null)
    {
        DiamondPool diamondPool = new DiamondPool(objectPrefabsList, objectPoolSize, objectsHolder);
        base.OnInitPool(diamondPool);
    }

    protected override void Spawn(List<Diamond> _prefabsArray, float[] _rangeSpawnPosition, Transform _prefabsHolder)
    {
        base.Spawn(_prefabsArray, _rangeSpawnPosition, _prefabsHolder);
        SetSpeed(objectSpeed);
    }
}
