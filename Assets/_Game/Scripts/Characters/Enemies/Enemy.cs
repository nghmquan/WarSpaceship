using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy setting")]
    [SerializeField] private float speed;
    [SerializeField] private List<string> tagsDestroyList = new List<string>();
    public Action<Enemy> OnEnemyReturnToPool { get; set; }

    [Header("Launcher setting")]
    [SerializeField] private float timeToShoot;
    private BulletPool lazerPool;
    private float shootTimer;

    private void Start()
    {
        OnInit();
    }

    void Update()
    {
        Move();
        Shoot();
    }

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (tagsDestroyList.Contains(_collision.gameObject.tag))
        {
            OnEnemyReturnToPool?.Invoke(this);
        }
    }

    private void OnInit()
    {
        shootTimer = timeToShoot;
    }

    public void SetLazerPool(BulletPool _lazerPool)
    {
        lazerPool = _lazerPool;
    }

    public void SetSpeed(float _speed)
    {
        speed = _speed;
    }

    private void Move()
    {
        Vector2 targetPosition = transform.position + new Vector3(0, speed * Time.deltaTime, 0);
        transform.position = targetPosition;
    }

    private void Shoot()
    {
        shootTimer -= Time.deltaTime;
        if(shootTimer <= 0f)
        {
            GetBulletFromPool();
            shootTimer = timeToShoot;
        }
    }

    public void GetBulletFromPool()
    {
        Bullet lazer = lazerPool?.GetObjectFromPool();
        if (lazer != null)
        {
            lazer.transform.position = transform.position;
            lazer.gameObject.SetActive(true);
        }
    }
}
