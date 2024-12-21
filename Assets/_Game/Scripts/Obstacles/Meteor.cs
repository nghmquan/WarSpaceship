using System;
using UnityEngine;

public class Meteor : Obstacle
{
    public Action<Meteor> OnMeteorReturnToPool { get; set; }

    private void Update()
    {
        Move(moveSpeed);
    }

    public void SetSpeed(float _moveSpeed)
    {
        moveSpeed = _moveSpeed;
    }

    protected override void OnTriggerEnter2D(Collider2D _collision)
    {
        if (tagDestroyList.Contains(_collision.gameObject.tag))
        {
            OnMeteorReturnToPool?.Invoke(this);
        }
    }
}