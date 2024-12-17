using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    [SerializeField] private Vector3 mouseWorldPosition;
    public Vector3 MouseWorldPosition { get => mouseWorldPosition; }

    private void Awake()
    {
        if (InputManager.instance != null)
        {
            Debug.LogError("Only 1 InputManager allow to exist.");
        }
        InputManager.instance = this;
    }

    private void FixedUpdate()
    {
        GetMousePosition();
    }

    protected virtual void GetMousePosition()
    {
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
