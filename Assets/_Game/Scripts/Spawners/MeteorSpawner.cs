using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : Spawner<Meteor>
{
    public void SetSpeed(float _speed)
    {
        objectMoveSpeed = _speed;
    }

    public void StartSpawnMeteor()
    {
        StartCoroutine(DelayTimeToSpawn(timeToSpawn));
    }

    public override void OnInit()
    {
        objectPool = new MeteorPool(objectPrefabsList, objectPoolSize, objectsHolder);
    }

    protected override IEnumerator DelayTimeToSpawn(float _timeToSpawn)
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeToSpawn);
            Spawn(objectPrefabsList, rangeSpawnPosition, objectsHolder);
        }
    }

    protected override void Spawn(List<Meteor> _prefabsArray, float[] _rangeSpawnPosition, Transform _prefabsHolder)
    {
        float randomSpawnPosition = Random.Range(_rangeSpawnPosition[0], _rangeSpawnPosition.Length);
        var randomSpawnObject = new Vector2(randomSpawnPosition, transform.position.y);

        Meteor meteor = objectPool.GetObjectFromPool();
        meteor.SetSpeed(objectMoveSpeed);
        if (meteor != null)
        {
            meteor.transform.position = randomSpawnObject;
            meteor.gameObject.SetActive(true);
        }
    }
}