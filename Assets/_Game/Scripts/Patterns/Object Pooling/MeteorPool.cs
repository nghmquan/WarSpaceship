using UnityEngine;

public class MeteorPool : ObjectPool<Meteor>
{
    public MeteorPool(Meteor _objectPrefab, int _poolSize, Transform _objectHolder = null) : base(_objectPrefab, _poolSize, _objectHolder)
    {

    }

    public new Meteor GetObjectFromPool()
    {
        Meteor meteor = base.GetObjectFromPool();
        meteor.OnMeteorReturnPool = ReturnObjectToPool;
        return meteor;
    }

    public new void ReturnObjectToPool(Meteor _meteor)
    {
        _meteor.OnMeteorReturnPool = null;
        base.ReturnObjectToPool(_meteor);
    }
}
