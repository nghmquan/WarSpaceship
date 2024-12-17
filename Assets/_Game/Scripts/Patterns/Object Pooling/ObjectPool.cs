using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ObjectPool<T> where T : MonoBehaviour
{
    protected Queue<T> poolObject;
    protected List<T> objectPrefabsList;
    protected Transform objectHolder;

    public ObjectPool(List<T> _objectPrefabsList, int _poolSize, Transform _objectHolder = null)
    {
        
        objectPrefabsList = _objectPrefabsList;
        objectHolder = _objectHolder;
        poolObject = new Queue<T>();

        //Initialize object prefab
        for(int i = 0; i < _poolSize; i++)
        {
            T ranmdomPrefab = objectPrefabsList[Random.Range(0, objectPrefabsList.Count)];
            T obj = Object.Instantiate(ranmdomPrefab, _objectHolder);
            obj.gameObject.SetActive(false);
            poolObject.Enqueue(obj);
        }
    }

    //Get object from pool object.
    public T GetObjectFromPool()
    {
        if(poolObject.Count > 0)
        {
            T obj = poolObject.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            T ranmdomPrefab = objectPrefabsList[Random.Range(0, objectPrefabsList.Count)];
            T obj = Object.Instantiate(ranmdomPrefab, objectHolder);
            obj.gameObject.SetActive(true);
            return obj;
        }
    }

    //Return object to pool object.
    public void ReturnObjectToPool(T _obj)
    {
        _obj.gameObject.SetActive(false);
        if(objectHolder != null)
        {
            _obj.transform.SetParent(objectHolder);
        }
        else
        {
            _obj.transform.SetParent(null);
        }
        poolObject.Enqueue(_obj);
    }
}

