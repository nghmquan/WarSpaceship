using System;
using UnityEngine;

public class Diamond : Obstacle
{
    public Action<Diamond> OnDiamondReturnToPool { get; set; }

    private void Update()
    {
        Move(moveSpeed);
    }

    public void SetSpeed(float _moveSpeed)
    {
        moveSpeed = _moveSpeed;
    }

    protected override void OnTriggerEnter2D(Collider2D _collider)
    {
        if (tagDestroyList.Contains(_collider.gameObject.tag))
        {
            OnDiamondReturnToPool?.Invoke(this);
        }
    }
}
