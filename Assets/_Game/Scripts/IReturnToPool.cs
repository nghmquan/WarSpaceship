using System;

public interface IReturnToPool<T>
{
    void ReturnToPool();
    Action<T> OnReturnToPool { get; set; }
}
