using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    protected override void Awake()
    {
        base.Awake();
    }

    public bool IsMouseButtonDownThisFrame() => Input.GetMouseButtonDown(0);

    public bool IsRightMouseButtonDownThisFrame() => Input.GetMouseButtonDown(1);

    // This button is for testing purposes, remove it later
    public bool IsTButtonDownThisFrame() => Input.GetKeyDown(KeyCode.T);

    public Vector2 GetMouseScreenPosition() => Input.mousePosition;
}
