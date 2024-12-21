using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : Spawner<Coin>
{
    public void SetSpeed(float _speed)
    {
        objectMoveSpeed = _speed;
    }

    public void StartSpawnCoin()
    {
        StartCoroutine(DelayTimeToSpawn(timeToSpawn));
    }

    public override void OnInit()
    {
        objectPool = new CoinPool(objectPrefabsList, objectPoolSize, objectsHolder);
    }
    protected override IEnumerator DelayTimeToSpawn(float _timeToSpawn)
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeToSpawn);
            Spawn(objectPrefabsList, rangeSpawnPosition, objectsHolder);
        }
    }

    protected override void Spawn(List<Coin> _prefabsArray, float[] _rangeSpawnPosition, Transform _prefabsHolder)
    {
        float randomSpawnPosition = Random.Range(_rangeSpawnPosition[0], _rangeSpawnPosition.Length);
        var randomSpawnObject = new Vector2(randomSpawnPosition, transform.position.y);

        Coin coin = objectPool.GetObjectFromPool();
        coin.SetSpeed(objectMoveSpeed);
        if (coin != null)
        {
            coin.transform.position = randomSpawnObject;
            coin.gameObject.SetActive(true);
        }
    }
}
