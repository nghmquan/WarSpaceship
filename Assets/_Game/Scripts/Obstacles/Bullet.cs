using System;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet setting")]
    [SerializeField] private float speedBullet;
    [SerializeField] private List<string> tagDestroyList = new List<string>();
    public Action<Bullet> OnBulletReturnToPool { get; set; }

    private void Update()
    {
        Move(speedBullet);
    }

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (tagDestroyList.Contains(_collision.gameObject.tag))
        {
            OnBulletReturnToPool?.Invoke(this);
        }
    }

    private void Move(float _moveSpeed)
    {
        transform.position = transform.position + new Vector3(0, _moveSpeed * Time.deltaTime, 0);
    }
}
