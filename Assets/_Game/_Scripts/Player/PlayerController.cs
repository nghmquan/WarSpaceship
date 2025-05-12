using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Setting")]
    [SerializeField] private Player player;
    [SerializeField] private Bullet bullet;

    void Start()
    {
        InitializePlayer();
    }

    
    void Update()
    {
        MoveSpeed();
        Shoot();
    }

    private void InitializePlayer()
    {
        player.SetSpeed(5);
    }

    private void MoveSpeed()
    {
        currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition = new Vector3(currentMousePosition.x, transform.position.y, transform.position.z);

    }
}
