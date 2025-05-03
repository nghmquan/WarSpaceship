using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    //Khai báo và khởi tạo pool cho các gameObject theo kiểu dữ liệu T
    private Dictionary<string, Queue<Component>> objectsPool = new Dictionary<string, Queue<Component>>();

    public T GetFromPool<T>(string _key, T _t, Transform _objectHolder) where T : Component
    {
        Type type = typeof(T);

        //Nếu chưa có pool
        if (!objectsPool.ContainsKey(_key)) 
        {
            objectsPool[_key] = new Queue<Component>();
        }

        //Nếu pool có gameObject chưa dùng
        if (objectsPool[_key].Count > 0)
        {
            //Lấy gameObject ra khỏi pool và active
            T obj = objectsPool[_key].Dequeue() as T;
            obj.gameObject.SetActive(true);
            return obj;
        }
        else //Nếu pool rỗng thì tạo mới hoặc gameObject chưa trở về pool thì tạo mới
        {
            T newObject = Instantiate(_t, _objectHolder);
            return newObject;
        }
    }


    public void ReturnToPool<T>(string _key, T _t) where T : Component
    {
        //Kiểm tra pool xem key có tồn tại hay chưa
        if (!objectsPool.ContainsKey(_key))
        {
            objectsPool[_key] = new Queue<Component>();
        }

        _t.gameObject.SetActive(false);
        objectsPool[_key].Enqueue(_t);
    }
}
