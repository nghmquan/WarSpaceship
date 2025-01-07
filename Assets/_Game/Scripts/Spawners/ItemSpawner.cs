using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Spawner<Item>
{
    protected override void OnInitPool(ObjectPool<Item> _objectPool = null)
    {
        ItemPool itemPool = new ItemPool(objectPrefabsList, objectPoolSize, objectsHolder);
        base.OnInitPool(itemPool);
        for (int i = 0; i < objectPrefabsList.Count; i++)
        {
            Item item = objectPrefabsList[i].GetComponent<Item>();
            if (item != null)
            {
                item.SetItemId(i + 1);
            }
            else
            {
                Debug.LogError("Item component missing on prefab at index: " + i);
            }
        }
    }

    protected override void Spawn(List<Item> _prefabsArray, float[] _rangeSpawnPosition, Transform _prefabsHolder)
    {
        base.Spawn(_prefabsArray, _rangeSpawnPosition, _prefabsHolder);
        objectPrefab.SetSpeed(objectSpeed);
    }
}
