using System.Collections.Generic;
using System;
using UnityEngine;

public class Obstacle: MonoBehaviour
{
    [Header("Obstacle Setting")]
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected List<string> tagDestroyList = new List<string>();

    protected virtual void Move(float _moveSpeed)
    {
        Vector2 newPosition = transform.position + new Vector3(0, -_moveSpeed * Time.deltaTime, 0);
        transform.position = newPosition;
    }

    protected virtual void OnTriggerEnter2D(Collider2D _collider)
    {

    }
}
