using System;
using UnityEngine;

public class Meteor : Obstacle
{
    public Action<Meteor> OnMeteorReturnToPool { get; set; }

    private void Update()
    {
        Move(speedObstacle);
    }

    protected override void OnTriggerEnter2D(Collider2D _collision)
    {
        if (tagDestroyList.Contains(_collision.gameObject.tag))
        {
            if (_collision.gameObject.CompareTag("Magnet"))
            {
                return;
            }
            OnMeteorReturnToPool?.Invoke(this);
        }
    }
}