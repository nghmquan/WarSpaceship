using System;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speedOfLazer;
    [SerializeField] private List<string> tagDestroyList = new List<string>();
    public Action<Bullet> OnBulletReturnToPool { get; set; }

    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (tagDestroyList.Contains(_collision.gameObject.tag))
        {
            GameManager.Instance.IncreaseMeteorHitCount();
            OnBulletReturnToPool?.Invoke(this);
        }
    }

    private void Move()
    {
        transform.position = transform.position + new Vector3(0, speedOfLazer * Time.deltaTime, 0);
    }
}
