using System.Collections.Generic;
using UnityEngine;

public class DiamondPool : ObjectPool<Diamond>
{
    public DiamondPool(List<Diamond> _objectPrefabsList, int _poolSize, Transform _objectHolder = null) : base(_objectPrefabsList, _poolSize, _objectHolder)
    {
    }

    public override Diamond GetObjectFromPool()
    {
        Diamond diamond = base.GetObjectFromPool();
        diamond.OnDiamondReturnToPool = ReturnObjectToPool;
        return diamond;
    }

    public new void ReturnObjectToPool(Diamond _diamond)
    {
        _diamond.OnDiamondReturnToPool = null;
        base.ReturnObjectToPool(_diamond);
    }
}
