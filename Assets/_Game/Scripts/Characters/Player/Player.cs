using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player setting")]
    [SerializeField] private Vector3 worldPosition;
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool isShield = false;

    [Header("Launcher setting")]
    [SerializeField] private List<Bullet> bulletPrefabsList;
    [SerializeField] private Transform bulletsHolder;
    [SerializeField] private int bulletSize;
    [SerializeField] private float timeToShoot;
    private BulletPool bulletPool;

    [Header("Items setting")]
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject magnet;
    [SerializeField ]private int itemId;

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
            if (isShield) return;
            Destroy(gameObject);
        }

        if (_collider.gameObject.CompareTag("Item"))
        {
            Item item = _collider.gameObject.GetComponent<Item>();
            itemId = item.GetItemId();
            if(item != null)
            {
                if(itemId == 1)
                {
                    shield.SetActive(true);
                    isShield = true;
                }
                else if(itemId == 2)
                {
                    magnet.SetActive(true);
                }
            }
           
        }
    }

    private void OnInit()
    {
        bulletPool = new BulletPool(bulletPrefabsList, bulletSize, bulletsHolder);
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
