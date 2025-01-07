using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [Header("Object Spawn Setting")]
    [SerializeField] protected List<T> objectPrefabsList;
    [SerializeField] protected Transform objectsHolder;
    [SerializeField] protected float[] rangeSpawnPosition;
    [SerializeField] protected float timeToSpawn;
    protected T objectPrefab;

    [Header("Object pool")]
    [SerializeField] protected int objectPoolSize;
    protected ObjectPool<T> objectPool;
    protected float objectSpeed;

    public virtual void Initialize()
    {
        OnInitPool();
    }

    protected virtual void OnInitPool(ObjectPool<T> _objectPool = null)
    {
        if(_objectPool == null)
        {
            objectPool = new ObjectPool<T>(objectPrefabsList, objectPoolSize, objectsHolder);
        }
        else
        {
            objectPool = _objectPool;
        }
    }

    public void StartSpawing()
    {
        StartCoroutine(DelayTimeToSpawn(timeToSpawn));
    }

    public void StopSpawing()
    {
        StopAllCoroutines();
        objectsHolder.gameObject.SetActive(false);
    }

    public virtual void SetSpeed(float _speed)
    {
        objectSpeed = _speed;
    }

    public virtual void CustomObjectPrefab(T _t)
    {
       
    }

    protected virtual IEnumerator DelayTimeToSpawn(float _timeToSpawn)
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeToSpawn);
            Spawn(objectPrefabsList, rangeSpawnPosition, objectsHolder);
        }
    }

    protected virtual void Spawn(List<T> _prefabsArray, float[] _rangeSpawnPosition, Transform _prefabsHolder)
    {
        float randomSpawnPosition = Random.Range(_rangeSpawnPosition[0], _rangeSpawnPosition.Length);
        var randomSpawnObject = new Vector2(randomSpawnPosition, transform.position.y);

        objectPrefab = objectPool.GetObjectFromPool();
        CustomObjectPrefab(objectPrefab);
        if (objectPrefab != null)
        {
            objectPrefab.transform.position = randomSpawnObject;
            objectPrefab.gameObject.SetActive(true);
        }
        
    }
}
