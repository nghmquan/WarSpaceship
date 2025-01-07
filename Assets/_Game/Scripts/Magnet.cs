using TMPro.EditorUtilities;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private Obstacle obstacle;
    [SerializeField] private bool isCollectCoin = false;

    private void Update()
    {
        if (isCollectCoin)
        {
            MoveToPlayer(obstacle);
        }
    }

    private void OnTriggerEnter2D(Collider2D _collider)
    {
        if (_collider.gameObject.CompareTag("Coin"))
        {
            obstacle = _collider.gameObject.GetComponent<Obstacle>();
            isCollectCoin = true;
        }
        else
        {
            isCollectCoin = false;
        }
    }

    private void MoveToPlayer(Obstacle _obstacle)
    {
        _obstacle.SetSpeed(10f);
        Vector3 coinDirection = (Player.Instance.transform.position - _obstacle.transform.position).normalized;
        _obstacle.transform.Translate(_obstacle.GetSpeed() * coinDirection * Time.deltaTime);
    }
}
