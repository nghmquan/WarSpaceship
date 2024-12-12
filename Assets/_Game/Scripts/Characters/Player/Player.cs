using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player setting")]
    [SerializeField] private Vector3 worldPosition;
    [SerializeField] private float moveSpeed;

    [Header("Launcher setting")]
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform bulletsHolder;
    [SerializeField] private float timeToShoot;
    private BulletPool bulletPool;

    private void Start()
    {
        OnInit();
        StartCoroutine(DelayTimeToShoot());
    }

    private void Update()
    {
        if (Input.GetMouseButton(0)) //If player holds down the left mouse button
        {
            GetTargetPosition();
            Move();
        }
    }

    private void OnTriggerEnter2D(Collider2D _collider)
    {
        if (_collider.gameObject.CompareTag("Meteor"))
        {
            Destroy(gameObject);
        }
    }

    private void OnInit()
    {
        bulletPool = new BulletPool(bulletPrefab, 10, bulletsHolder);
    }

    private void GetTargetPosition()
    {
        worldPosition = InputManager.Instance.MouseWorldPosition;
        worldPosition.z = 0;
    }

    private void Move()
    {
        Vector2 targetPosition = new Vector3(worldPosition.x, transform.position.y, transform.position.z);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed);
    }

    //This method make player to shoot out bullet
    private void Shoot()
    {
        Bullet bullet = bulletPool.GetObjectFromPool();
        bullet.transform.position = transform.position;
        bullet.gameObject.SetActive(true);
    }

    private IEnumerator DelayTimeToShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToShoot);
            Shoot();
        }
    }
}
