using UnityEngine;

public class Bullet : Obstacle, IPoolable
{
    [SerializeField] private float speed;
    private Vector3 viewportPosition;

    void Update()
    {
        MoveSpeed();
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float _speed)
    {
        speed = _speed;
    }

    public void MoveSpeed()
    {
        viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if(viewportPosition.y > 1)
        {
            BulletPool.Instance.ReturnObjectToPool(this.GetGameObjectTag(), this.gameObject);
        }
    }

    public void OnSpawned()
    {
        
    }

    public void OnDisposed()
    {
        
    }
}
