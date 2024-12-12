using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : Spawner<Meteor>
{
    [Header("Meteor Spawner Setting")]
    [SerializeField] private Transform meteorsHolder;
    [SerializeField] private List<Meteor> meteorPrefabsList;
    [SerializeField] private float[] rangeSpawnPosition;
    [SerializeField] private float timeToSpawn;

    [Header("Meteor Pool")]
    [SerializeField] private int meteorPoolSize;
    private MeteorPool meteorPool;
    private float meteorSpeed;

    public void Initialize()
    {
        OnInit();
    }

    public void SetSpeed(float _speed)
    {
        meteorSpeed = _speed;
    }

    public void StartSpawnMeteor()
    {
        StartCoroutine(DelayTimeToSpawn(timeToSpawn));
    }

    private void OnInit()
    {
        Meteor randomMeteor = meteorPrefabsList[Random.Range(0, meteorPrefabsList.Count)];
        meteorPool = new MeteorPool(randomMeteor, meteorPoolSize, meteorsHolder);
    }

    protected override IEnumerator DelayTimeToSpawn(float _timeToSpawn)
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeToSpawn);
            Spawn(meteorPrefabsList, rangeSpawnPosition, meteorsHolder);
        }
    }

    protected override void Spawn(List<Meteor> _prefabsArray, float[] _rangeSpawnPosition, Transform _prefabsHolder)
    {
        float randomSpawnPosition = Random.Range(_rangeSpawnPosition[0], _rangeSpawnPosition.Length);
        var randomSpawnObject = new Vector2(randomSpawnPosition, transform.position.y);

        Meteor meteor = meteorPool.GetObjectFromPool();
        meteor.SetSpeed(meteorSpeed);
        if(meteor != null)
        {
            meteor.transform.position = randomSpawnObject;
            meteor.gameObject.SetActive(true);
        }
    }
}
