using System.Collections.Generic;
using UnityEngine;

public class CoinPool : ObjectPool<Coin>
{
    public CoinPool(List<Coin> _objectPrefabsList, int _poolSize, Transform _objectHolder = null) : base(_objectPrefabsList, _poolSize, _objectHolder)
    {
    }

    public override Coin GetObjectFromPool()
    {
        Coin coin = base.GetObjectFromPool();
        coin.OnCoinReturnToPool = ReturnObjectToPool;
        return coin;
    }

    public new void ReturnObjectToPool(Coin _coin)
    {
        _coin.OnCoinReturnToPool = null;
        base.ReturnObjectToPool(_coin);
    }
}
