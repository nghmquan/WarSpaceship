using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    public void SetSpeed(float _speed)
    {
        objectMoveSpeed = _speed;
    }

    public void StartSpawnEnemy()
    {
        StartCoroutine(DelayTimeToSpawn(timeToSpawn));
    }

    public override void OnInit()
    {
        objectPool = new EnemyPool(objectPrefabsList, objectPoolSize, objectsHolder);
    }

    protected override IEnumerator DelayTimeToSpawn(float _timeToSpawn)
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeToSpawn);
            Spawn(objectPrefabsList, rangeSpawnPosition, objectsHolder);
        }
    }

    protected override void Spawn(List<Enemy> _prefabsArray, float[] _rangeSpawnPosition, Transform _prefabsHolder)
    {
        float randomSpawnPosition = Random.Range(_rangeSpawnPosition[0], _rangeSpawnPosition.Length);
        var randomSpawnObject = new Vector2(randomSpawnPosition, transform.position.y);

        Enemy enemy = objectPool.GetObjectFromPool();
        enemy.SetSpeed(objectMoveSpeed);
        if (enemy != null)
        {
            enemy.transform.position = randomSpawnObject;
            enemy.gameObject.SetActive(true);
        }
    }
}