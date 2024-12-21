using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Spawner<Item>
{
    public void SetSpeed(float _moveSpeed)
    {
        objectMoveSpeed = _moveSpeed;
    }

    public void StartSpawnItem()
    {
        StartCoroutine(DelayTimeToSpawn(timeToSpawn));
    }

    public override void OnInit()
    {
        objectPool = new ItemPool(objectPrefabsList, objectPoolSize, objectsHolder);
        for (int i = 0; i < objectPrefabsList.Count; i++)
        {
            Item item = objectPrefabsList[i].GetComponent<Item>();
            if (item != null)
            {
                item.SetItemId(i + 1);
            }
            else
            {
                Debug.LogError("Item component missing on prefab at index " + i);
            }
        }
    }

    protected override IEnumerator DelayTimeToSpawn(float _timeToSpawn)
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeToSpawn);
            Spawn(objectPrefabsList, rangeSpawnPosition, objectsHolder);
        }
    }

    protected override void Spawn(List<Item> _prefabsArray, float[] _rangeSpawnPosition, Transform _prefabsHolder)
    {
        float randomSpawnPosition = Random.Range(0, _rangeSpawnPosition.Length);
        var randomSpawnItem = new Vector2(randomSpawnPosition, transform.position.y);

        Item item = objectPool.GetObjectFromPool();
        item.SetSpeed(objectMoveSpeed);
        if (item != null)
        {
            item.transform.position = randomSpawnItem;
            item.gameObject.SetActive(true);
        }

    }
}
