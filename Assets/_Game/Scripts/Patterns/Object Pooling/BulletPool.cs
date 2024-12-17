using System.Collections.Generic;
using UnityEngine;

public class BulletPool : ObjectPool<Bullet>
{
    public BulletPool(List<Bullet> _objectPrefab, int _poolSize, Transform _objectHolder = null) : base(_objectPrefab, _poolSize, _objectHolder)
    {

    }

    public new Bullet GetObjectFromPool()
    {
        Bullet bullet = base.GetObjectFromPool();
        bullet.OnBulletReturnToPool = ReturnObjectToPool;
        return bullet;
    }

    public new void ReturnObjectToPool(Bullet _bullet)
    {
        _bullet.OnBulletReturnToPool = null;
        base.ReturnObjectToPool(_bullet);
    }
}
