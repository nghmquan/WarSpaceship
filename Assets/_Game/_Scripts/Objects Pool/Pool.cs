using Unity.Collections;
using UnityEngine;

[System.Serializable]
public class Pool
{
    [SerializeField, ReadOnly] private string prefabTag;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform prefabHolder;
    [SerializeField] private int poolSize;

    public string GetPrefabTag()
    {
        prefabTag = prefab.GetComponent<Obstacle>().GetGameObjectTag();
        return prefabTag;
    }

    public GameObject GetPrefab()
    {
        return prefab;
    }

    public Transform GetPrefabHolder()
    {
        return prefabHolder;
    }

    public void SetPrefabHolder(Transform _prefabHolder)
    {
        prefabHolder = _prefabHolder;
    }

    public int GetPoolSize()
    {
        return poolSize;
    }
}
