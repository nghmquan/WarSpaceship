using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Setting")]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerShot playerShot;
    [SerializeField] private bool canShot;
    [SerializeField] private float timeToShot;
    
    void Start()
    {
        //Initialize player 
        InitializePlayer();
    }
    
    void Update()
    {
        //Player move
        playerMovement.MoveSpeed();

        //Player shot a bullet
        playerShot.Shot(canShot, timeToShot);
    }

    private void InitializePlayer()
    {
        playerMovement.SetSpeed(5);
        playerShot.SetShoting(canShot);
        playerShot.SetTimeToShot(0.2f);
    }
}