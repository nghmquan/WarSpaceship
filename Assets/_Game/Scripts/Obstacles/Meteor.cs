using System;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Obstacle
{
    [Header("Meteor Setting")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private List<string> tagDestroyList = new List<string>();
    public Action<Meteor> OnMeteorReturnPool { get; set; }

    private void Update()
    {
        Move(moveSpeed);
    }

    public void SetSpeed(float _speed)
    {
        moveSpeed = _speed;
    }

    protected override void OnTriggerEnter2D(Collider2D _collision)
    {
        if (tagDestroyList.Contains(_collision.gameObject.tag))
        {
            OnMeteorReturnPool?.Invoke(this);
        }
    }
}
