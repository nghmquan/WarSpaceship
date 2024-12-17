using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Spawner<Item>
{
    [Header("Item Spawn Setting")]
    [SerializeField] private List<Item> itemPrefabsList;
    [SerializeField] private Transform itemsHolder;
    [SerializeField] private float[] rangeSpawnPosition;
    [SerializeField] private float timeToSpawn;

    [Header("Item pool")]
    [SerializeField] private int itemPoolSize;
    private ItemPool itemPool;
    private float itemMoveSpeed;

    public void StartSpawnItem()
    {
        StartCoroutine(DelayTimeToSpawn(timeToSpawn));
    }

    public void SetSpeed(float _moveSpeed)
    {
        itemMoveSpeed = _moveSpeed;
    }

    public void Initialize()
    {
        OnInit();
    }

    public void OnInit()
    {
        itemPool = new ItemPool(itemPrefabsList, itemPoolSize, itemsHolder);
        for (int i = 0; i < itemPrefabsList.Count; i++)
        {
            Item item = itemPrefabsList[i].GetComponent<Item>();
            if(item != null)
            {
                item.SetItemId(i+1);
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
            Spawn(itemPrefabsList, rangeSpawnPosition, itemsHolder);
        }
    }

    protected override void Spawn(List<Item> _prefabsArray, float[] _rangeSpawnPosition, Transform _prefabsHolder)
    {
        float randomSpawnPosition = Random.Range(0, _rangeSpawnPosition.Length);
        var randomSpawnItem = new Vector2(randomSpawnPosition, transform.position.y);

        Item item = itemPool.GetObjectFromPool();
        item.SetSpeed(itemMoveSpeed);
        if(item != null)
        {
            item.transform.position = randomSpawnItem;
            item.gameObject.SetActive(true);
        }
        
    }
}
