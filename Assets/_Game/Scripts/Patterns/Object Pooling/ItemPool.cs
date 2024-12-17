using System.Collections.Generic;
using UnityEngine;

public class ItemPool : ObjectPool<Item>
{
    public ItemPool(List<Item> _objectPrefabsList, int _poolSize, Transform _objectHolder = null) : base(_objectPrefabsList, _poolSize, _objectHolder)
    {
    }

    public new Item GetObjectFromPool()
    {
        Item item = base.GetObjectFromPool();
        item.OnItemReturnToPool = ReturnObjectToPool;
        return item;
    }

    public new void ReturnObjectToPool(Item _item)
    {
        _item.OnItemReturnToPool = null;
        base.ReturnObjectToPool(_item);
    }
}
