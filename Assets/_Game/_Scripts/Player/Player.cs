using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int speed;

    public int GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(int _speed)
    {
        speed = _speed;
    }
}
