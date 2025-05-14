using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool 
{
    public string tag;
    public GameObject prefab;
    public Transform prefabHolder;
    public int poolSize;
}

public class PoolManager : MonoBehaviour
{
    private void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        BulletPool.Instance.CreatePool();
    }
}
