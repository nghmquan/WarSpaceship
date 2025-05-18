using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Khởi tạo pool genetic T và T có kế thừa Component và IPoolable
/// </summary>
public class ObjectPool<T> : Singleton<ObjectPool<T>> where T : Component, IPoolable
{
    [SerializeField] protected List<Pool> pools; //Khởi tạo danh sách các pools
    private Dictionary<string, Queue<T>> poolDictionary; //Dictionary để lưu trữ các pool theo tác

    public virtual void CreatePool()
    {
        poolDictionary = new Dictionary<string, Queue<T>>(); //Khai báo để khởi tạo Dictionary

        foreach (Pool pool in pools) //Khởi tạo pool để chạy trong vòng lăp của danh sách pools
        {
            if (!poolDictionary.ContainsKey(pool.tag)) //Kiểm tra đối tượng pool.tag có tồn tại trong Dictionary hay không.
            {
                Queue<T> objectPool = new Queue<T>(); //Khởi tạo một hằng đợi Queue

                Transform parent = pool.prefabHolder != null ? pool.prefabHolder : transform; //Khởi tạo Transform parent để gán pool.prefabHolder

                for(int index = 0; index < pool.poolSize; index++) //Cho index chạy vòng lặp for
                {
                    GameObject gameObject = Instantiate(pool.prefab, parent); //Khởi tạo gameObject để sinh pool.prefab và gán parent
                    T poolableObject = gameObject.GetComponent<T>(); //khởi tạo poolable và gán gameObject lấy component theo kiểu dữ liệu

                    if(poolableObject != null) //Kiểm trả poolable có null hay không
                    {
                        gameObject.SetActive(false); //Cài đặt đối tượng ẩn đị
                        objectPool.Enqueue(poolableObject);// Thêm đối tượng và queue objectPool
                    }
                    else
                    {
                        Debug.Log($"Prefab {pool.prefab.name} does not have a component of type {typeof(T)} or does not implement IPoolable");
                        //Destroy luôn object bị lỗi
                        Destroy(gameObject);
                    }
                }

                poolDictionary.Add(pool.tag, objectPool); //Thêm pool.tag và queue objetPool vào poolDciotnary
            }
        }
    }

    public virtual void ClearPool()
    {
        foreach (var pool in poolDictionary)
        {
            foreach (var obj in pool.Value)
            {
                Destroy(obj.gameObject);
            }
        }
    }

    public virtual IEnumerator SpawnRandomObject(bool _isSpawn, float _timeSpawn, float _minPosition, float _maxPosition)
    {
        //while (_isSpawn)
        //{
        //    var objective = Random.Range(_minPosition, _maxPosition);
        //    var position = new Vector3(objective, transform.position.y);
        //    GameObject gameObject = Instantiate(prefab[Random.Range(0, prefab.Length)],position,Quaternion.identity);
        yield return new WaitForSeconds(_timeSpawn);
        //    Destroy(gameObject, 5f);
        //}
    }
}