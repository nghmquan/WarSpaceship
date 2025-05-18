using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


/// <summary>
/// 
/// </summary>
public class ObjectPool : Singleton<ObjectPool>
{
    [SerializeField] private List<Pool> poolList;
    private Queue<GameObject> objectPoolQueue;
    private Dictionary<string, Queue<GameObject>> objectPoolDictionary;

    public virtual void CreatePool()
    {
        objectPoolDictionary = new Dictionary<string, Queue<GameObject>>();
        objectPoolQueue = new Queue<GameObject>();

        foreach (var objective in poolList)
        {
            if (!objectPoolDictionary.ContainsKey(objective.GetPrefabTag()))
            {
                Transform gameObjectHolder = Instantiate(gameObject.transform, this.transform);
                gameObjectHolder.gameObject.name = objective.GetPrefabTag() + " Pool";

                for (int index = 0; index < objective.GetPoolSize(); index++)
                {
                    GameObject gameOject = Instantiate(objective.GetPrefab(), gameObjectHolder);
                    gameOject.SetActive(false);
                    objectPoolQueue.Enqueue(gameOject);
                }

                objectPoolDictionary.Add(objective.GetPrefabTag(), objectPoolQueue);
            }
            else
            {
                Debug.Log($"GameObject with tag '{objective.GetPrefabTag()}' has already exist.");
            }
        }
    }

    public virtual GameObject GetObjectFromPool(string _gameObjectTag)
    {
        if (!objectPoolDictionary.ContainsKey(_gameObjectTag))
        {
            Debug.LogError($"GameObject with tag '{_gameObjectTag}' does not exist.");
            return null;
        }
        else
        {
            if (objectPoolQueue.Count > 0)
            {
                GameObject gameObject = objectPoolQueue.Dequeue();
                if (gameObject.TryGetComponent<IPoolable>(out var poolable))
                {
                    gameObject.SetActive(true);
                    poolable.OnSpawned();
                    return gameObject;
                }
                else
                {
                    Debug.LogWarning("GameObject does not implement IPoolable.");
                    return null;
                }
            }
            else
            {
                foreach (var objective in poolList)
                {
                    if (objective.GetPrefabTag() != _gameObjectTag) { continue; }

                    GameObject gameObject = Instantiate(objective.GetPrefab(), objective.GetPrefabHolder());
                    if (gameObject.TryGetComponent<IPoolable>(out var poolable))
                    {
                        gameObject.SetActive(true);
                        poolable.OnSpawned();
                        return gameObject;
                    }
                    else
                    {
                        Debug.LogWarning("GameObject does not implement IPoolable.");
                        return null;
                    }
                }
            }
        }
        return null;
    }

    public virtual void ReturnObjectToPool(string _gameObjectTag, GameObject _gameObjectInPool)
    {
        if(objectPoolDictionary.TryGetValue(_gameObjectTag, out var objectPoolQueue))
        {
            _gameObjectInPool.SetActive(false);
            objectPoolQueue.Enqueue(_gameObjectInPool);
            return;
        }
        Debug.LogWarning($"GameObject with tag '{_gameObjectTag}' does not exist.");
    }
}