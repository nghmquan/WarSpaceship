using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Setting")]
    [SerializeField] private Player player;
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform bulletHolder;

    private Vector2 currentMousePosition;
    private Vector3 targetPosition;


    void Start()
    {
        InitializePlayer();
    }

    
    void Update()
    {
        MoveSpeed();
        Shoot();
    }

    private void InitializePlayer()
    {
        player.SetSpeed(5);
        bullet.SetSpeed(5);
    }

    private void MoveSpeed()
    {
        currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition = new Vector3(currentMousePosition.x, transform.position.y, transform.position.z);

        if (Input.GetMouseButton(0))
        {
            this.transform.position = Vector2.MoveTowards(transform.position, targetPosition, player.GetSpeed());
        }
    }

    private void Shoot()
    {
        Bullet _bullet = ObjectPool.Instance.GetFromPool("Bullet", bullet, bulletHolder);
        _bullet.transform.position = transform.position;
    }

}
