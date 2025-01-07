using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    [SerializeField] private List<string> tagDestroyList = new List<string>();
    private Player player;

    public void SetPlayer(Player _player)
    {
        player = _player;
    }

    private void OnTriggerEnter2D(Collider2D _collider)
    {
        if (_collider.gameObject.CompareTag("Item")) 
        {
            Item item = _collider.gameObject.GetComponent<Item>();
            var itemId = item.GetItemId();
            if (item != null)
            {
                if (itemId == 1)
                {
                    player.ActiveShield(true);
                }

                if (itemId == 2)
                {
                    player.ActiveMagnet(true);
                }
            }

        }

        if (tagDestroyList.Contains(_collider.gameObject.tag))
        {
            player.Death();
        }
    }
}
