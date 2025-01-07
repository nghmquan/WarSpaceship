using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class Obstacle: MonoBehaviour
{
    [Header("Obstacle Setting")]
    [SerializeField] protected float speedObstacle;
    [SerializeField] protected List<string> tagDestroyList = new List<string>();

    protected virtual void OnTriggerEnter2D(Collider2D _collider)
    {

    }

    public float GetSpeed()
    {
        return speedObstacle;
    }

    public void SetSpeed(float _speed)
    {
        speedObstacle = _speed;
    }

    protected virtual void Move(float _moveSpeed)
    {
        Vector2 newPosition = transform.position + new Vector3(0, -_moveSpeed * Time.deltaTime, 0);
        transform.position = newPosition;
    }

}
