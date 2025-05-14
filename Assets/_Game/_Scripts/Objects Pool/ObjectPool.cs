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

    //Phương thức khởi tạo pool
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
            else
            {
                Debug.LogWarning($"Pool with tag '{pool.tag}' already exists.");
            }
        }
    }

    //Phương thức lấy đối tượng từ pool theo kiểu dữ liệu T lấy từ tham số chuỗi tag
    public virtual T GetObjectFromPool(string _tag)
    {
        if (!poolDictionary.ContainsKey(_tag)) //Kiểm tra xem có tag trong pool dictionary không
        {
            Debug.LogError($"Pool with tag '{_tag}' does not exist!");
            return null;
        }

        Queue<T> objectPool = poolDictionary[_tag]; //Khởi tạo biến object pool và gán tag từ poolDictionary

        if (objectPool.Count > 0) //Kiểm trong objectPool có hay không
        {
            T objective = objectPool.Dequeue(); //Lấy đối tượng ra khỏi queue
            objective.gameObject.SetActive(true); //Kích hoạt đối tượng
            objective.OnSpawned(); // Gọi hàm OnSpawned
            return objective;
        }
        else
        {
            // Mở rộng pool nếu cần thiết (tùy chọn)
            foreach (Pool poolData in pools)
            {
                if (poolData.tag != _tag) { continue; } 
                if (poolData != null)
                {
                    Transform parent = poolData.prefabHolder != null ? poolData.prefabHolder : transform;
                    GameObject obj = Instantiate(poolData.prefab, parent);
                    T poolableObj = obj.GetComponent<T>();
                    if (poolableObj != null)
                    {
                        obj.SetActive(true);
                        poolableObj.OnSpawned();
                        return poolableObj;
                    }
                    else
                    {
                        Debug.LogError($"Prefab {poolData.prefab.name} does not have a component of type {typeof(T)} or does not implement IPoolable.");
                        Destroy(obj);
                        return null;
                    }

                }
            }

            //Pool poolData = pools.Find(p => CompareTag(p.tag)); // Tìm Pool data tương ứng
            Debug.LogWarning($"Pool with tag '{{tag}}' is out of objects!");
            return null; // Trả về null nếu Pool rỗng
        }
    }

    //Hàm trả đói tượng về pool
    public virtual void ReturnObjectToPool(string _tag, T _object)
    {
        if (!poolDictionary.ContainsKey(_tag))
        {
            Debug.LogError($"Pool with tag '{_tag}' does not exist");
            return; // Trả về nếu Pool không tồn tại
        }

        _object.gameObject.SetActive(false);
        _object.OnDisposed();
        poolDictionary[_tag].Enqueue(_object);
    }

    public virtual void ClearPool()
    {
        foreach (var pool in poolDictionary)
        {
            foreach (var obj in pool.Value)
            {
                Destroy(obj.gameObject);
            }
            pool.Value.Clear();
        }
        poolDictionary.Clear();
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