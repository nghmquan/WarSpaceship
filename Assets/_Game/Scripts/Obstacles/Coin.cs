using System;
using UnityEngine;

public class Coin : Obstacle
{
    //[SerializeField] private bool isPlayerMove = false;
    public Action<Coin> OnCoinReturnToPool { get; set; }

    private void Update()
    {
        Move(speedObstacle);
    }

    protected override void OnTriggerEnter2D(Collider2D _collider)
    {
        if (tagDestroyList.Contains(_collider.gameObject.tag))
        {
            //isPlayerMove = false;
            OnCoinReturnToPool?.Invoke(this);
        }

        if (_collider.gameObject.CompareTag("Magnet"))
        {
            //isPlayerMove = true;
        }

    }

    public void MoveToPlayer()
    {
        speedObstacle = 10f;
        Vector3 coinDirection = (Player.Instance.transform.position - transform.position).normalized;
        transform.Translate(speedObstacle * Time.deltaTime * coinDirection);
    }
}
