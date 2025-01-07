using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerSpawner : MonoBehaviour
{
    [Header("Lazer Pool")]
    [SerializeField] private List<Bullet> lazerPrefabsList;
    [SerializeField] private int lazerPoolSize;
    [SerializeField] private Transform lazerHolder;
    private BulletPool lazerPool;

    public void Initialize()
    {
        OnInit();
    }

    public BulletPool GetLazerPool()
    {
        return lazerPool;
    }

    private void OnInit()
    {
        lazerPool = new BulletPool(lazerPrefabsList, lazerPoolSize, lazerHolder);
    }
}
