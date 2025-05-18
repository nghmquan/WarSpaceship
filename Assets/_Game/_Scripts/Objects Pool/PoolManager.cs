using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;

    private void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        bulletPool.CreatePool();
    }
}
