using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    [Header("Player setting")]
    [SerializeField] private Vector3 worldPosition;
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool isDeath = false;

    [Header("Player Get Items")]
    [SerializeField] private PlayerDetect playerDetect;
    [SerializeField] private bool isShield = false;
    [SerializeField] private bool isMagnet = false;

    [Header("Launcher setting")]
    [SerializeField] private List<Bullet> bulletPrefabsList;
    [SerializeField] private Transform bulletsHolder;
    [SerializeField] private int bulletSize;
    [SerializeField] private float timeToShoot;
    private BulletPool bulletPool;

    [Header("Items setting")]
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject magnet;
    [SerializeField] private int itemId;

    private void Start()
    {
        OnInit();
        StartCoroutine(DelayTimeToShoot());
    }

    private void Update()
    {
        if (isDeath == true) { Debug.Log("IsDeath +" + isDeath); return; }

        if (Input.GetMouseButton(0)) //If player holds down the left mouse button
        {
            GetTargetPosition();
            Move();
        }
    }

    public void ActiveShield(bool _isActive)
    {
        isShield = _isActive;
        shield.SetActive(isShield);
    }

    public void ActiveMagnet(bool _isActive)
    {
        isMagnet = _isActive;
        magnet.SetActive(isMagnet);
    }

    private void OnInit()
    {
        bulletPool = new BulletPool(bulletPrefabsList, bulletSize, bulletsHolder);

        playerDetect.SetPlayer(this);
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

    public bool GetIsDeath()
    {
        return isDeath;
    }

    public void Death()
    {
        isDeath = true;
        bulletsHolder.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
