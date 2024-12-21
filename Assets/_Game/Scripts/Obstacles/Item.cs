using System;
using System.Collections.Generic;
using UnityEngine;

public class Item : Obstacle
{
    [Header("Item Setting")]
    [SerializeField] private int itemId;
    public Action<Item> OnItemReturnToPool { get; set; }

    private void Update()
    {
        Move(moveSpeed);
    }

    public int GetItemId()
    {
        return itemId;
    }

    public void SetItemId(int _itemId)
    {
        itemId = _itemId;
    }

    public void SetSpeed(float _moveSpeed)
    {
        moveSpeed = _moveSpeed;
    }

    protected override void OnTriggerEnter2D(Collider2D _collider)
    {
        if (tagDestroyList.Contains(_collider.gameObject.tag))
        {
            OnItemReturnToPool?.Invoke(this);
        }
    }
}
