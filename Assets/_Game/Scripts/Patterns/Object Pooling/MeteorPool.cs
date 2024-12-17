using System.Collections.Generic;
using UnityEngine;

public class MeteorPool : ObjectPool<Meteor>
{
    public MeteorPool(List<Meteor> _objectPrefabsList, int _poolSize, Transform _objectHolder = null) : base(_objectPrefabsList, _poolSize, _objectHolder)
    {
    }

    public new Meteor GetObjectFromPool()
    {
        Meteor meteor = base.GetObjectFromPool();
        meteor.OnMeteorReturnToPool = ReturnObjectToPool;
        return meteor;
    }

    public new void ReturnObjectToPool(Meteor _meteor)
    {
        _meteor.OnMeteorReturnToPool = null;
        base.ReturnObjectToPool(_meteor);
    }
}