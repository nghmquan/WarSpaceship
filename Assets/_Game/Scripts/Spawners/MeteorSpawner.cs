using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : Spawner<Meteor>
{
    protected override void OnInitPool(ObjectPool<Meteor> _objectPool = null)
    {
        MeteorPool meteoPool = new MeteorPool(objectPrefabsList, objectPoolSize, objectsHolder);
        base.OnInitPool(meteoPool);
    }

    public override void CustomObjectPrefab(Meteor _t)
    {
        _t.SetSpeed(objectSpeed);
    }

    protected override void Spawn(List<Meteor> _prefabsArray, float[] _rangeSpawnPosition, Transform _prefabsHolder)
    {
        base.Spawn(_prefabsArray, _rangeSpawnPosition, _prefabsHolder);
    }
}