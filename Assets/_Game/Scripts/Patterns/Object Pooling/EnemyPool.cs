using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : ObjectPool<Enemy>
{
    public EnemyPool(List<Enemy> _objectPrefabsList, int _poolSize, Transform _objectHolder = null) : base(_objectPrefabsList, _poolSize, _objectHolder)
    {
    }

    public override Enemy GetObjectFromPool()
    {
        Enemy enemy = base.GetObjectFromPool();
        enemy.OnEnemyReturnToPool = base.ReturnObjectToPool;
        return enemy;
    }

    public new void ReturnObjectToPool(Enemy _enemy)
    {
        _enemy.OnEnemyReturnToPool = null;
        base.ReturnObjectToPool(_enemy);
    }
}
