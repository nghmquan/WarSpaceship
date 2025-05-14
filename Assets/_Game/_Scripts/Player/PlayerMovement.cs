using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector2 currentMousePosition;
    private Vector3 targetPosition;

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float _speed)
    {
        speed = _speed;
    }

    public void MoveSpeed()
    {
        currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        targetPosition = new Vector3(currentMousePosition.x, transform.position.y, transform.position.z);

        if (Input.GetMouseButton(0))
        {
            transform.parent.position = Vector2.MoveTowards(transform.parent.position, targetPosition, speed);
        }
    }
}
