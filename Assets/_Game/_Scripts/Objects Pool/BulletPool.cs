using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : ObjectPool<Bullet>
{
    public override void CreatePool()
    {
        base.CreatePool();
    }

    public override Bullet GetObjectFromPool(string _tag)
    {
        return base.GetObjectFromPool(_tag);
    }

    public override void ReturnObjectToPool(string _tag, Bullet _object)
    {
        base.ReturnObjectToPool(_tag, _object);
    }

    public override void ClearPool()
    {
        base.ClearPool();
    }
}
