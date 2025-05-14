using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Setting")]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerShot playerShot;
    [SerializeField] private bool isShot;
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
        playerShot.SetShoting(isShot);
        playerShot.Shot();
    }

    private void InitializePlayer()
    {
        playerMovement.SetSpeed(5);
        playerShot.SetTimeToShot(timeToShot);
    }
}