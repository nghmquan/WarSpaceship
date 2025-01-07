using System;
using UnityEngine;

public class Item : Obstacle
{
    [Header("Item Setting")]
    [SerializeField] private int itemId;
    public Action<Item> OnItemReturnToPool { get; set; }

    private void Update()
    {
        Move(speedObstacle);
    }

    public int GetItemId()
    {
        return itemId;
    }

    public void SetItemId(int _itemId)
    {
        itemId = _itemId;
    }

    protected override void OnTriggerEnter2D(Collider2D _collider)
    {
        if (tagDestroyList.Contains(_collider.gameObject.tag))
        {
            OnItemReturnToPool?.Invoke(this);
        }
    }
}
