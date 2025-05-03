using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;
    public static T Instance => instance;

    [SerializeField] protected bool dontDestroyOverLoad;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            if (dontDestroyOverLoad)
            {
                DontDestroyOnLoad(this);
            }

            CustomAwake();
        }
        else
        {
            Destroy(instance);
        }
    }

    protected virtual void CustomAwake() { }
}