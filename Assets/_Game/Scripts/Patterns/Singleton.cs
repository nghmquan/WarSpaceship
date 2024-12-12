using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    protected static T instance;
    public static T Instance { get => instance; }

    [SerializeField] protected bool dontDestroyOverLoad;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            if (dontDestroyOverLoad)
            {
                Destroy(this);
            }
        }
        else
        {
            Destroy(instance);
        }
    }
}
