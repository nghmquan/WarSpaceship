using System;
using UnityEngine;

public class Diamond : Obstacle
{
    public Action<Diamond> OnDiamondReturnToPool { get; set; }

    private void Update()
    {
        Move(speedObstacle);
    }

    protected override void OnTriggerEnter2D(Collider2D _collider)
    {
        if (tagDestroyList.Contains(_collider.gameObject.tag))
        {
            OnDiamondReturnToPool?.Invoke(this);
        }
    }
}
