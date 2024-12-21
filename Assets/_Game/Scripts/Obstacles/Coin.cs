using System;
using UnityEngine;

public class Coin : Obstacle
{
    public Action<Coin> OnCoinReturnToPool { get; set; }

    private void Update()
    {
        Move(moveSpeed);
    }

    public void SetSpeed(float _speed)
    {
        moveSpeed = _speed;
    }

    protected override void OnTriggerEnter2D(Collider2D _collider)
    {
        if (tagDestroyList.Contains(_collider.gameObject.tag))
        {
            OnCoinReturnToPool?.Invoke(this);
        }
    }
}
