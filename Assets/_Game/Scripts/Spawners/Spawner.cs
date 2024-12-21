using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [Header("Object Spawn Setting")]
    [SerializeField] protected List<T> objectPrefabsList;
    [SerializeField] protected Transform objectsHolder;
    [SerializeField] protected float[] rangeSpawnPosition;
    [SerializeField] protected float timeToSpawn;

    [Header("Object pool")]
    [SerializeField] protected int objectPoolSize;
    protected ObjectPool<T> objectPool;
    protected float objectMoveSpeed;

    public virtual void Initialize()
    {
        OnInit();
    }

    public virtual void OnInit()
    {
        //objectPool = new ObjectPool<T>(objectPrefabsList, objectPoolSize, objectsHolder);
    }

    protected virtual IEnumerator DelayTimeToSpawn(float _timeToSpawn)
    {
        yield return new WaitForSeconds(_timeToSpawn);
    }

    protected virtual void Spawn(List<T> _prefabsArray, float[] _rangeSpawnPosition, Transform _prefabsHolder)
    {
        float randomSpawnPosition = Random.Range(0, _rangeSpawnPosition.Length);
        var randomSpawnObject = new Vector2(randomSpawnPosition, transform.position.y);

        T prefabToSpawn = _prefabsArray[Random.Range(0, _prefabsArray.Count)];
        Instantiate(prefabToSpawn, randomSpawnObject, Quaternion.identity, _prefabsHolder);

        T t = objectPool.GetObjectFromPool();
        if (t != null)
        {
            t.transform.position = randomSpawnObject;
            t.gameObject.SetActive(true);
        }
    }
}
