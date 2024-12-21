using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondSpawner : Spawner<Diamond>
{
    public void SetSpeed(float _moveSpeed)
    {
        objectMoveSpeed = _moveSpeed;
    }

    public void StartSpawnDiamond()
    {
        StartCoroutine(DelayTimeToSpawn(timeToSpawn));
    }

    public override void OnInit()
    {
        objectPool = new DiamondPool(objectPrefabsList, objectPoolSize, objectsHolder);
    }

    protected override IEnumerator DelayTimeToSpawn(float _timeToSpawn)
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeToSpawn);
            Spawn(objectPrefabsList, rangeSpawnPosition, objectsHolder);
        }
    }

    protected override void Spawn(List<Diamond> _prefabsArray, float[] _rangeSpawnPosition, Transform _prefabsHolder)
    {
        float randomSpawnPosition = Random.Range(_rangeSpawnPosition[0], _rangeSpawnPosition.Length);
        var randomSpawnObject = new Vector2(randomSpawnPosition, transform.position.y);

        Diamond diamond = objectPool.GetObjectFromPool();
        diamond.SetSpeed(objectMoveSpeed);
        if (diamond != null)
        {
            diamond.transform.position = randomSpawnObject;
            diamond.gameObject.SetActive(true);
        }
    }
}
