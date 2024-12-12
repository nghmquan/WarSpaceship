using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ObjectPool<T> where T : MonoBehaviour
{
    protected Queue<T> poolObject;
    protected T objectPrefab;
    protected Transform objectHolder;

    public ObjectPool(T _objectPrefab, int _poolSize, Transform _objectHolder = null)
    {
        
        objectPrefab = _objectPrefab;
        objectHolder = _objectHolder;
        poolObject = new Queue<T>();

        //Initialize object prefab
        for(int i = 0; i < _poolSize; i++)
        {
            T obj = Object.Instantiate(_objectPrefab, _objectHolder);
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
            T obj = Object.Instantiate(objectPrefab, objectHolder);
            objectHolder.gameObject.SetActive(true);
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

