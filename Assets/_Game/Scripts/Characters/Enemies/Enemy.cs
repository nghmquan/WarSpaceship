using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy setting")]
    [SerializeField] private float speed;
    [SerializeField] private List<string> tagsDestroyList = new List<string>();
    public Action<Enemy> OnEnemyReturnToPool { get; set; }

    [Header("Launcher setting")]
    [SerializeField] private List<Bullet> bulletPrefabsList;
    [SerializeField] private Transform bulletsHolder;
    [SerializeField] private int bulletSize;
    [SerializeField] private float timeToShoot;
    private BulletPool bulletPool;

    private void Start()
    {
        OnInit();
        StartCoroutine(DelayTimeToShoot());
    }

    void Update()
    {
        Move();
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
        bulletPool = new BulletPool(bulletPrefabsList, bulletSize, bulletsHolder);
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

    public void Shoot()
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
