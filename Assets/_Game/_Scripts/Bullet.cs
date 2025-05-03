using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int speed;
    private Vector3 viewportPosition;

    void Update()
    {
        MoveSpeed();
    }

    public int GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(int _speed)
    {
        speed = _speed;
    }

    public void MoveSpeed()
    {
        viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if(viewportPosition.y > 1)
        {
            ObjectPool.Instance.ReturnToPool("Bullet", this);
        }
    }
}
